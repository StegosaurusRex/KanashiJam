using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MirrorBlur : MonoBehaviour
{
    public Transform target;
    public float blurAmount = 1f;
    public float hpLossRate = 1f; // how much HP is lost per second of looking at the target
    private PostProcessVolume volume;
    private DepthOfField depthOfField;
    private float timeLookingAtTarget = 0f;
    private bool isLookingAtTarget = false;

    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out depthOfField);
    }

    void Update()
    {
        if (IsLookingAtTarget())
        {
            isLookingAtTarget = true;
            timeLookingAtTarget += Time.deltaTime;
            SetBlurAmount(blurAmount);
        }
        else
        {
            isLookingAtTarget = false;
            timeLookingAtTarget = 0f;
            SetBlurAmount(0f);
        }

        //if (isLookingAtTarget)
        //{
        //    PlayerController playerController = target.GetComponent<PlayerController>();
        //    if (playerController != null)
        //    {
        //    hp -= 1;
        //        playerController.health -= hpLossRate * Time.deltaTime;
        //    }
        //}
    }

    bool IsLookingAtTarget()
    {
        Vector3 directionToTarget = target.position - Camera.main.transform.position;
        float angle = Vector3.Angle(Camera.main.transform.forward , directionToTarget);
        return angle < 30f; // adjust this angle to change the threshold for "looking at" the target
    }

    void SetBlurAmount(float amount)
    {
        depthOfField.focalLength.value = amount;
    }
}