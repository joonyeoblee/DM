using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClimbingManager : MonoBehaviour
{
    [SerializeField] private Text timerText; // 진행 중 타이머 텍스트
    [SerializeField] private Text endTimerText; // 종료 시 표시 타이머 텍스트

    public bool isTimerStart = false; // 타이머 시작 여부
    public bool endTimer = false; // 타이머 종료 여부

    private float progressTime = 0; // 진행 시간

    private void Update()
    {
        if (isTimerStart && !endTimer)
        {
            // 진행 시간 업데이트
            progressTime += Time.deltaTime;

            // 진행 중 타이머 텍스트 갱신
            timerText.text = FormatTime(progressTime);
        }

        // 종료 상태라면 텍스트 갱신
        if (endTimer)
        {
            isTimerStart = false;

            // 종료 텍스트 갱신
            endTimerText.text = FormatTime(progressTime);
        }
    }

    public void StartTimer()
    {
        isTimerStart = true;
        progressTime = 0; // 타이머 초기화
        timerText.text = FormatTime(progressTime);
        // endTimerText.text = "";
    }

    public void TimesUp()
    {
        endTimer = true;
    }

    // 딜레이 후 대화 시작
    public void StartDialogueAfterDelay()
    {
        StartCoroutine(StartDialogueAfter1secondsDelay());
    }

    private IEnumerator StartDialogueAfter1secondsDelay()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.csvReader.StartDialogue(3);

        // 목표 활성화
        yield return new WaitForSeconds(5f);
        foreach (var target in GameManager.Instance.targets)
        {
            target.SetActive(true);
        }
    }

    // 시간을 "분:초" 형식으로 변환
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}
