using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playButton;
    public GameObject pauseButton;

    public enum GameMode
    {
        SinglePlayer,
        AIPlayer
    }

    public GameMode gameMode;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {

        string sceneName = SceneManager.GetActiveScene().name;
        
        switch(gameMode)
        {
            case GameMode.SinglePlayer:
                SceneManager.LoadScene("SinglePlayer");
                break;

            case GameMode.AIPlayer:
                SceneManager.LoadScene("AIPlayer");
                break;
        }

        Time.timeScale = 1;
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        playButton.SetActive(false);
    }

    public void HomeScreen()
    {
        SceneManager.LoadScene(0);
    }
}
