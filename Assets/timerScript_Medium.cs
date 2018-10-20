using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timerScript_Medium : MonoBehaviour {

    public static int timeLeft = 80;
    public Text countdownText;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("countdown");
    }

    // Update is called once per frame
    void Update()
    {

        countdownText.text = ("Time Left: " + timeLeft);

        if (timeLeft <= 0)
        {
            StopCoroutine("countdown");
            countdownText.text = "Time's UP!";

            SceneManager.LoadScene(sceneName: "Menu");
        }

    }

    IEnumerator countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
