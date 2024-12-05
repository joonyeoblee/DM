using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class ClimingTrigger : MonoBehaviour
{
    // 물체가 파괴시 생성될 오브젝트
    [SerializeField]
    private GameObject triggered;


    // 트리거 오브젝트 활성화
    public void AttiveTriggred()
    {
        if (triggered != null)
        {
            triggered.SetActive(true);
        }
    }

    public void StartDialogueAfterDelay()
    {
        StartCoroutine(StartDialogueAfter5secondsDelay());
    }

    IEnumerator StartDialogueAfter5secondsDelay()
    {
        yield return new WaitForSeconds(5f);
        GameManager.Instance.csvReader.StartDialogue(3);
        yield return new WaitForSeconds(10f);
        for (int i = 0; i < GameManager.Instance.targets.Length; i++)
        {
            GameManager.Instance.targets[i].SetActive(true);
        }
    }
}
