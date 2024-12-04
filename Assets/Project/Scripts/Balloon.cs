using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
public class Balloon : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Damageable dmg = gameObject.GetComponent<Damageable>();
            dmg.DealDamage(100);
        }
    }
}
