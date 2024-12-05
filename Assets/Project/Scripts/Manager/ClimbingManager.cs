using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClimbingManager : MonoBehaviour
{
    // 시작할때 텍스트
    [SerializeField]
    private Text timerText;
    // 클라이밍 종료 위치에 있는 텍스트
    [SerializeField]
    private Text endTimerText;

    // 타이머 시작 여부
    public bool isTimerStart = false;

    // 타이머 종료 여부
    public bool endTimer = false;

    // 타이머 진행 시간
    public float progressTime = 0;
    private void Update()
    {
        if (isTimerStart)
        {
            // 타이머 진행 시간
            progressTime += Time.deltaTime;
            // 타이머 텍스트 크기 조절
            timerText.fontSize = 24;

            // 타이머 텍스트 분:초로 표시
            timerText.text = $"{progressTime / 60:00}:{progressTime % 60:00}";

            // 타이머 종료시 종료 텍스트 분:초로 표시
            if (endTimer)
            {
                isTimerStart = false;
                endTimerText.fontSize = 24;


                endTimerText.text = $"{progressTime / 60:00}:{progressTime % 60:00}";
            }

        }
    }

    // 타이머 시작
    public void StartTimer()
    {
        isTimerStart = true;
    }

    // 타이머 종료
    public void TimesUp()
    {
        endTimer = true;
    }


}
