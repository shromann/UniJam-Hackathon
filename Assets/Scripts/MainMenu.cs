using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject controlsScreen;
	public GameObject creditsScreen;

	public void PlayGame(){
		SceneManager.LoadScene(1);
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void Controls()
    {
		controlsScreen.SetActive(true);
    }

	public void ControlsExit()
    {
		controlsScreen.SetActive(false);
    }

	public void Credits()
    {
		creditsScreen.SetActive(true);
    }

	public void CreditsExit()
    {
		creditsScreen.SetActive(false);
    }

}
