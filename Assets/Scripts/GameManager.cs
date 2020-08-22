using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int lives = 5;
    private int score = 1;
    private float latestUpdate = 0;

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
        if (Time.time - latestUpdate >= 0.25f)
        {
            //double scoreF = 0.0005 * Time.time;
            //Debug.Log(scoreF);
            score += 1;

            latestUpdate = Time.time;
        }

        

        scoreText.text = score.ToString();            

    }





}
