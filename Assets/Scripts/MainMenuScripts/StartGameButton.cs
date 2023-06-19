using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
public class StartGameButton : MonoBehaviour
{
    [SerializeField]private Button startButton;
    [SerializeField]private Animator startAnim;
    [SerializeField] private int timeToStartGame;
    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }
    void StartGame()
    {
        startButton.gameObject.SetActive(false);
        startAnim.SetTrigger("Start");
        StartCoroutine(DelayedStart());
    }
    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(timeToStartGame);
        SceneManager.LoadScene("GameScene");
    }

}
