using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEnemiesTrigger : MonoBehaviour
{
    [SerializeField] private GameObject objectToDeActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToDeActivate.SetActive(false);
        }
    }
}
