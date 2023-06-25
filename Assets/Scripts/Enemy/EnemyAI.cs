using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float originalSpeed;
    [SerializeField] private float timeToPlayTrack;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float soundTimer;
    [SerializeField] private float soundCooldown;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the audio source component

        // Load the audio clip
        audioSource.clip = audioClip;
    }
    void Update()
    {
        soundTimer -= Time.deltaTime;
        if (IsVisibleInCamera())
        { 
            StopMoving();

        }
        else
        {
            // Load the audio clip
            
            StartMoving();
            SetDestination();
            SetSpeed();
        }
    }



    private bool IsVisibleInCamera()
    {
        return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(playerCamera) , GetComponent<Renderer>().bounds);
    }

    private void StopMoving()
    {
        navMeshAgent.speed = 0f;
        audioSource.Stop();
        
    }

    private void StartMoving()
    {
        currentSpeed = originalSpeed;
        if (soundTimer <= 0)
        {
            audioSource.Play();
            soundTimer = soundCooldown;
        }
    }


    private void SetDestination()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }

    private void SetSpeed()
    {
        navMeshAgent.speed = currentSpeed;
    }

    IEnumerator EnemiesStepsSounds()
    {

        yield return new WaitForSeconds(timeToPlayTrack);
        audioSource.Play();
        
    }


}