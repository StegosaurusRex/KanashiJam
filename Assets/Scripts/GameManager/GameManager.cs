using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator imageAnim;
    [SerializeField] private Animator imageAliveAnim;
    [SerializeField] private Animator youWon;
    [SerializeField] private PlayerHP playerHP;
    [SerializeField] private EnemyAI enemyAI;
    [SerializeField]private FirstPersonController characterController; 
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private AudioClip audioClipDead;
    [SerializeField] private AudioClip audioClipAlive;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private float timeToDeath;
    [SerializeField] private float timeToWin;
    [SerializeField] private float timeToExit;
    [SerializeField] private GameObject pauseMenuUIGameOver;
    [SerializeField] private GameObject audioManager;
    
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerHP playerHP = GetComponent<PlayerHP>();
        EnemyAI enemyAI = GetComponent<EnemyAI>();
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Load the audio clip
        
        audioSource.clip = audioClipAlive;
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {

                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (playerHP.hp <= 0)
        {
            GameOverScreen();
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        characterController.RotationSpeed = 1f;
        Time.timeScale = 1f;
        Cursor.visible = false;
        GameIsPaused = false;


    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        characterController.RotationSpeed = 0f;
        Time.timeScale = 0f;
        GameIsPaused = true;


    }
  
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Resume();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    
    public void GameOverScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        characterController.MoveSpeed = 0f;
        imageAnim.SetTrigger("Death");
        StartCoroutine(WaitingBeforeDead());
        

    }

    IEnumerator WaitingBeforeDead()
    {

        yield return new WaitForSeconds(timeToDeath);
        playerHP.audioSource.Stop();
        audioSource.clip = audioClipDead;
        audioSource.Play();
        pauseMenuUIGameOver.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }


    public void GameWinScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        characterController.MoveSpeed = 0f;
        Destroy(audioManager);
        imageAliveAnim.SetTrigger("Live");
        StartCoroutine(WaitingBeforeWin());
        

    }
    IEnumerator WaitingBeforeWin()
    {

        yield return new WaitForSeconds(timeToWin);
        audioSource.clip = audioClipAlive;
        audioSource.Play();
        Time.timeScale = 0f;
        GameIsPaused = true;
        yield return new WaitForSeconds(timeToExit);
        
        
    }

}
