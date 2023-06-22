using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float originalSpeed;
    [SerializeField] private Camera playerCamera;
    [SerializeField]private NavMeshAgent navMeshAgent;

    private void Start()
    {

    }
    void Update()
    {

        if (IsVisibleInCamera())
        { 
            StopMoving();

        }
        else
        {
            // Load the audio clip
            
            StartMoving();
            EnemiesFollowSound();
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
        
    }

    private void StartMoving()
    {
        currentSpeed = originalSpeed;
    }


    private void SetDestination()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }

    private void SetSpeed()
    {
        navMeshAgent.speed = currentSpeed;
    }

    private void EnemiesFollowSound()
    {
        
        
    }


}