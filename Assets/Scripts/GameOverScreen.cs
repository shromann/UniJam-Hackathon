using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("RunnerScene");
    }

    public void Quit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
