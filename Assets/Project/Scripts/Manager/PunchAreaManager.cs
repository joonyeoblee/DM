using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAreaManager : MonoBehaviour
{
    // spawne을 트리거 하기위한 count
    [SerializeField]
    private int count;

    // spawner를 통해 움직이는 타켓 소환
    [SerializeField]
    private GameObject spawner;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.csvReader.StartDialogue(1);

            // 2초 뒤 두 번째 대사 출력
            StartCoroutine(StartSecondDialogueAfterDelay());
        }
    }

    public void AddCount()
    {
        count++;

        if (count == 4)
        {
            GameManager.Instance.csvReader.StartDialogue(1);

            // 2초 뒤 두 번째 대사 출력
            StartCoroutine(StartSecondDialogueAfterDelay());
        }
    }

    private IEnumerator StartSecondDialogueAfterDelay()
    {
        yield return new WaitForSeconds(2f); // 2초 대기
        GameManager.Instance.csvReader.StartDialogue(2); // 두 번째 대사 출력
    }
}
