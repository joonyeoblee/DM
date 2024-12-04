using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckName : MonoBehaviour
{
    public Text text;
    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 물체의 이름 출력
        Debug.Log("충돌한 물체: " + collision.gameObject.name);

        text.text = "충돌한 물체: " + collision.gameObject.name;
    }

}
