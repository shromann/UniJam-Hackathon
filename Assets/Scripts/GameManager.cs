using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
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
    

    private void Start()
    {
        HealthChecker();
        // Make sure game over and pause screens turned off
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        // Reset time scale
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        Destroy(player);

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
            score += 1;

            latestUpdate = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
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

    private void Pause()
    {
        Time.timeScale = 0;

        pauseScreen.SetActive(true);
    }


}
