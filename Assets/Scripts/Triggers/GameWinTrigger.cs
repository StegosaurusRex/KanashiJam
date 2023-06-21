using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinTrigger : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void Start()
    {
        GameManager gameManager = GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.GameWinScreen();
        }
    }
}
