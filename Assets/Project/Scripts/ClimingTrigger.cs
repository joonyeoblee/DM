using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class ClimingTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject triggered;

    public void AttiveTriggred()
    {
        if (triggered != null)
        {
            triggered.SetActive(true);
        }
    }
}
