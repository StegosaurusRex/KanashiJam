using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesTrigger : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToActivate.SetActive(true);
        }
    }
}
