using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingTarget : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            gameObject.SetActive(false);
        }
    }
}
