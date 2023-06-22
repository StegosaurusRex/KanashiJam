using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Load the audio clip
        audioSource.clip = audioClip;

        // Play the audio clip
        audioSource.Play();
    }



}

