using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGameBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }

    public void StartGame()
    {
        timerScript.timeLeft = 90;
        scoreScript.scoreVal = 0;
        SceneManager.LoadScene(sceneName:"GAME");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MediumScene()
    {
        timerScript_Medium.timeLeft = 80;
        SceneManager.LoadScene(sceneName:"MEDIUM");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
