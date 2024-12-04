using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CSVReader : MonoBehaviour
{
    // CSV 파일 경로
    public string filePath; // 유니티 프로젝트 내부의 파일 경로
    private List<string[]> csvData = new List<string[]>(); // CSV 데이터 저장

    [SerializeField]
    private Text text; // 대사를 출력할 Text UI

    private string rowString;
    private int currentLineIndex = 0; // 현재 출력 중인 대사 인덱스
    private bool canDisplayDialogue = false; // 대사 표시 가능 여부

    void Start()
    {
        SetFilePath();
    }
    void SetFilePath()
    {
        if (filePath != null)
        {
            ReadCSV();
        }
    }

    // CSV 파일 읽기
    void ReadCSV()
    {
        // 파일 경로가 존재하는지 확인
        if (File.Exists(filePath))
        {
            // 파일을 읽어서 각 줄을 배열로 나눔
            string[] allLines = File.ReadAllLines(filePath);

            foreach (string line in allLines)
            {
                // 각 줄을 콤마(,) 기준으로 분리하여 배열로 저장
                string[] rowData = line.Split(',');

                // 분리된 데이터를 리스트에 추가
                csvData.Add(rowData);
            }

            // 대사 출력 시작은 버튼을 눌렀을 때
            canDisplayDialogue = true; // 대사 표시 가능
        }
        else
        {
            Debug.Log("CSV 파일을 찾을 수 없습니다. 경로를 확인해 주세요.");
        }
    }

    void Update()
    {
        // 1번 키가 눌렸을 때 대사를 출력
        if (Input.GetKeyDown(KeyCode.Alpha1)) // '1' 키 입력 시
        {
            // 대사 출력 시작
            StartCoroutine(DisplayDialogue());
        }
    }

    // 대사를 1초마다 출력하는 코루틴
    IEnumerator DisplayDialogue()
    {
        // 현재 대사를 출력
        while (currentLineIndex < csvData.Count)
        {
            rowString = string.Join(", ", csvData[currentLineIndex]); // 배열을 문자열로 변환

            // rowString이 비어있으면 출력 멈춤
            if (string.IsNullOrEmpty(rowString))
            {
                Debug.Log("빈 대사로 출력이 멈췄습니다.");
                canDisplayDialogue = false; // 대사 출력 중지
                currentLineIndex++;
                yield break; // 코루틴 종료
            }

            text.text = rowString; // UI에 대사 출력

            currentLineIndex++;
            yield return new WaitForSeconds(1f); // 1초 대기 후 대사 변경
        }
        canDisplayDialogue = false; // 대사 출력이 끝난 후 더 이상 입력을 받지 않음
    }
}
