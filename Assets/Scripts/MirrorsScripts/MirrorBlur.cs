using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MirrorBlur : MonoBehaviour
{
    [SerializeField] private float blurAmount;
    [SerializeField] private PostProcessVolume volume;
    [SerializeField] private new Camera camera;
    private DepthOfField depthOfField;
    [SerializeField]private float angleValue;
    public bool damageIsRecieving;
    private GameObject[] targets;

    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out depthOfField);

        // Find all objects with the "Target" tag
        targets = GameObject.FindGameObjectsWithTag("Mirror");
    }

    void Update()
    {
        if (IsLookingAtTarget())
        {
            SetBlurAmount(blurAmount);
            damageIsRecieving = true;
        }
        else
        {
            SetBlurAmount(0f);
            damageIsRecieving = false;
        }
    }

    bool IsLookingAtTarget()
    {
        foreach (GameObject target in targets)
        {
            if (target == null)
            {
                continue;
            }

            Vector3 directionToTarget = target.transform.position - camera.transform.position;
            float angle = Vector3.Angle(camera.transform.forward , directionToTarget);
            if (angle < angleValue)
            {
                return true;
            }
        }
        return false;
    }

    void SetBlurAmount(float amount)
    {
        depthOfField.focalLength.value = amount;
    }
}