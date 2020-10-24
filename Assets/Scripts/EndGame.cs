using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject endGame;
    public Text cause;

    private void Awake()
    {
        endGame.SetActive(false);
        Debug.Log(endGame.activeSelf);
    }
    public void GameOver(string causeGameOver)
    {
        Debug.Log("GameOver");

        GameObject.Find("Lantern").SetActive(false);
        Debug.Log("Lantern off");

        GameObject.Find("Timer").SetActive(false);
        Debug.Log("Timer off");

        GameObject.Find("SanityMeter").SetActive(false);
        Debug.Log("Sanity off");

        endGame.SetActive(true);
        Debug.Log("EndGame on");

        cause.text = causeGameOver;
        Debug.Log("Cause");

        Time.timeScale = 0;

        GameLogic.FailedLevel();
    }
}
