using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EnemyTouch : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public GameObject player;

    private bool isFading = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isFading = true;
            //player.GetComponent<PlayerController>().enabled = false;
        }
    }

    void Update()
    {
        if (isFading)
        {
            postProcessVolume.weight += Time.deltaTime;
            if (postProcessVolume.weight >= 1f)
            {
                isFading = false;
                postProcessVolume.weight = 1f;
            }
        }
    }
}