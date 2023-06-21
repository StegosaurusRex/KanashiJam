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
    [SerializeField] private PlayerHP playerHP;
    [SerializeField]private FirstPersonController characterController; 
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    [SerializeField] private float timeToDeath;
    [SerializeField] private float timeToWin;
    public GameObject pauseMenuUIGameOver;
    public GameObject pauseMenuUIWinGame;
    private void Start()
    {
        PlayerHP playerHP = GetComponent<PlayerHP>();
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

        pauseMenuUIGameOver.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Application.Quit();
    }


    public void GameWinScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        characterController.MoveSpeed = 0f;
        imageAliveAnim.SetTrigger("Live");
        StartCoroutine(WaitingBeforeWin());
        

    }
    IEnumerator WaitingBeforeWin()
    {

        yield return new WaitForSeconds(timeToWin);

        Time.timeScale = 0f;
        GameIsPaused = true;
        SceneManager.LoadScene(3);
    }

}
