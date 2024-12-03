using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Update()
    {
        // 앞으로 직진
        transform.Translate(0, 0, speed);
    }

    void OnDestroy()
    {
        Destroy(gameObject);
        GameManager.Instance.count++;
    }
}
