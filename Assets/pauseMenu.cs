using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {


    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void check()
    {
       
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);

    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(sceneName:"Difficulty");
    }
}
