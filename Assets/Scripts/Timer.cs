using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 300.0f;
    public Text timerText;
    public GameObject Ui;

    void Start()
    {
        timerText.text = time.ToString();
    }

    void Update()
    {
        time -= Time.deltaTime;
        timerText.text = Mathf.Round(time).ToString();

        isOver();
    }

    private void isOver()
    {
        if(Mathf.Round(time) <= 0) Ui.GetComponent<EndGame>().GameOver("Time is over");
    }
}
