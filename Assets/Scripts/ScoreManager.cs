using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //public int lives = 5;
    private int score = 1;
    private float latestUpdate = 0;
    private int playerHealth = 1;

    public Text livesText;
    public Text scoreText;
    public Text gameOverScore;

    public GameObject player;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;

    public AudioSource AudioInGame;
    public AudioSource PauseMenuSound;
    public AudioSource GameOverSound;


    private void Start()
    {
        HealthChecker();
        // Make sure game over and pause screens turned off
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        // Reset time scale
        Time.timeScale = 1;
        // Get the player health at the start of game.
        playerHealth = player.GetComponent<PlayerController>().health;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        GameOverSound.Play();
        Destroy(player);
        AudioInGame.Pause();

        // Makes everything stop 
        Time.timeScale = 0;
        gameOverScore.text = score.ToString();
        gameOverScreen.SetActive(true);
    }


    public void Update()
    {
        if (player != null)
        {
            HealthChecker();
        }
        
        if (Time.time - latestUpdate >= 0.25f)
        {
            score += (int) ( 0.8 * Time.time );

            latestUpdate = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.active)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
            
        }

        scoreText.text = score.ToString();            

    }

    private void HealthChecker()
    {

        if (playerHealth <= 0 || player.transform.position.y <= -5)
        {
            GameOver();
        }
        else
        {
            playerHealth = player.GetComponent<PlayerController>().health;

            livesText.text = playerHealth.ToString();
        }

    }


    // Public Methods to be accessed by buttons

    public void EnemyKillScore()
    {
        score += 500 + (int) (Time.time * 0.5);
        Debug.Log("ENEMY KILLED");
    }

    public void RestartGame()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("RunnerScene");
    }

    public void Pause()
    {
        Time.timeScale = 0;
        AudioInGame.Pause();
        PauseMenuSound.Play();
        pauseScreen.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        AudioInGame.Play();
        pauseScreen.SetActive(false);
    }

    public void Quit()
    {
        //Application.Quit();
        SceneManager.LoadScene("Menu");
    }


}
