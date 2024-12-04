using System.Collections;
using System.Collections.Generic;
using Strategy;
using UnityEngine;

public class ShootAreaManager : MonoBehaviour
{
    // spawne을 트리거 하기위한 count
    [SerializeField]
    private int count;

    // spawner를 통해 움직이는 타켓 소환
    [SerializeField]
    private GameObject spawner;

    public void AddCount()
    {
        count++;

        // 타켓이 전부 부서지면 spawner의 랜덤 타켓 트리거
        if (count == 3)
        {
            spawner.GetComponent<ClientStrategy>().ShootGameStart();
            GameManager.Instance.player.GetComponent<CSVReader>().StartDialogue();
        }
    }
}
