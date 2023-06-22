using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesTrigger : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private GameObject objectToActivate2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToActivate.SetActive(true);
            if (objectToActivate2 != null)
            {
                objectToActivate2.SetActive(true);
            }
        }
    }
}
