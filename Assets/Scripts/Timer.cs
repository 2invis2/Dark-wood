using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 300.0f;
    public Text timerText;

    void Start()
    {
        timerText.text = time.ToString();
    }

    void Update()
    {
        time -= Time.deltaTime;
        timerText.text = Mathf.Round(time).ToString();
    }
}
