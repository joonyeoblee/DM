using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int count;
    [SerializeField]
    private GameObject[] targets;

    // 싱글턴 패턴 적용
    private static GameManager _instance;
    public static GameManager Instance { get; private set; }
    [SerializeField]
    private GameObject SponPoint;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // 중복된 인스턴스를 파괴
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬이 전환되어도 유지
    }
    void Start()
    {
        count = 0;
    }

    void Update()
    {
        if (count == 4)
        {
            //여기에 이스터에그 4개 다 부신경우
        }
        else
        {
            //이스터에그를 다 부셔보라고 하기
        }
    }
}
