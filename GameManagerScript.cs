using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using UnityEngine.Audio;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject pausedPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject winPanel;

    public PlayerMovement playerMovement;

    public int minutes;
    public int seconds;

    [SerializeField] TMP_Text timerText;

    [SerializeField] Sprite[] toolsSprites;

    public ParticleSystem explosion;

    public AudioSource winSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausedPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator Timer()
    {
        while (true)
        {
            seconds -= 1;
            if (minutes == 0 && seconds < 0)
            {
                timerText.text = "00:00"; // Display 00:00 on the UI
                break; // Exit the loop
            }

            if (seconds <= 0)
            {
                if (minutes > 0)
                {
                    minutes--;
                    seconds = 59;

                }
            }

            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            yield return new WaitForSeconds(1);
        }

        explosion.Play();
        GameOver();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausedPanel.SetActive(true);
        playerMovement.pausedGame = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausedPanel.SetActive(false);
        playerMovement.pausedGame = false;
    }

    public void GameOver()
    {
        if (playerMovement != null)
        {
            playerMovement.canMove = false;
        }
        playerMovement.canMove = false;
        gameOverPanel.SetActive(true);
        winPanel.SetActive(false);

    }

    public void RetryGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void nextLevel()
    {
        Time.timeScale = 1;
        winPanel.SetActive(false);
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        SceneManager.LoadScene("SampleScene - berhane");
    }

    public void winLevel()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
        winSFX.Play();
    }
}
