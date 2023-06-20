using UnityEngine;
using UnityEngine.UI;

public class EnemyTouch : MonoBehaviour
{

    public GameObject player;

    [SerializeField]private GameManager gameManager;
    private void Start()
    {
        GameManager gameManager = GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            gameManager.GameOverScreen();
        }
    }

    void Update()
    {

    }

    }

