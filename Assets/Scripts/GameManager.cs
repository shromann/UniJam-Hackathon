using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int lives = 5;
    private int score = 1;

    //public Text livesText;
    public Text scoreText; 

    public void LoseLife (int i = 1)
    {
        lives -= 1;
        if (lives <= 0)
        {
            GameOver();
        }

    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Update()
    {
        double scoreF = 0.0005 * Time.deltaTime;
        score += 1 + (int) scoreF;

        scoreText.text = score.ToString();            

    }





}
