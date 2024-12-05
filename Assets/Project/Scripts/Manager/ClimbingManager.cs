using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClimbingManager : MonoBehaviour
{
    public Text timerText;
    public bool isTimerStart = false;
    public bool endTimer = false;

    public float progressTime = 0;
    private void Update()
    {
        if (isTimerStart)
        {
            // timer run
            progressTime += Time.deltaTime;
            // Increase the timer text size
            timerText.fontSize = 24;


            timerText.text = $"{progressTime / 60:00}:{progressTime % 60:00}";

            // Check if the ready time has expired
            if (endTimer)
                isTimerStart = false;
        }
    }
    public void StartTimer()
    {
        isTimerStart = true;
    }

    public void TimesUp()
    {
        endTimer = true;
    }


}
