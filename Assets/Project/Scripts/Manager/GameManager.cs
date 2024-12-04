using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int count;
    [SerializeField]
    public GameObject[] targets;
    [SerializeField]

    public GameObject player;
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
            // 사슴을 전부 잡은 경우
            Debug.Log("All Easter eggs destroyed!");
        }

    }

    public void AddCount()
    {
        count++;
        Debug.Log($"Current count: {count}");
    }


}
