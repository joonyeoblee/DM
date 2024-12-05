using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int count;
    [SerializeField]

    // 사슴 오브젝트 배열
    public GameObject[] targets;
    [SerializeField]
    private GameObject playerCanvas;

    public GameObject player;

    // CSVReader 스크립트관리 변수
    public CSVReader csvReader;
    // 싱글톤 인스턴스
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // 씬 전환시 유지
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        count = 0;
    }

    void Update()
    {
        if (count == 4)
        {
            // 사슴을 전부 잡은 경우 플레이어 캔버스 활성화
            playerCanvas.SetActive(true);

        }

    }

    // 사슴을 잡을때마다 카운트 증가
    public void AddCount()
    {
        count++;
        Debug.Log($"Current count: {count}");
    }


}
