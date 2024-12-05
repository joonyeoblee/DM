using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAreaManager : MonoBehaviour
{

    public void StartNextDialogue()
    {
        // 첫 번째 대사 출력
        GameManager.Instance.csvReader.StartDialogue(1);

        // 2초 뒤 두 번째 대사 출력
        StartCoroutine(StartSecondDialogueAfterDelay());
    }

    private IEnumerator StartSecondDialogueAfterDelay()
    {
        yield return new WaitForSeconds(2f); // 2초 대기
        GameManager.Instance.csvReader.StartDialogue(2); // 두 번째 대사 출력
    }
}
