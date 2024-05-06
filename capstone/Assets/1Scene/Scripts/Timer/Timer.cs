using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //bool timerActive = false;
    float currentTime;
    public float startMinutes;
    //public Text currentTimeText;
    public TextMeshPro currentTimeText;

    private void Start()
    {
        currentTime = startMinutes;
    }

    void Update()
    {
        /*if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
        }*/
        if (currentTime > 0)
        {
            currentTime = currentTime - Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
            }

            currentTimeText.text = currentTime.ToString("n2");
        }
    }
    
    /*public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }*/
}
