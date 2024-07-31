using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOnContact : MonoBehaviour
{
    bool healSwitch = true;

    private void OnTriggerEnter(Collider other)
    {
        if (healSwitch)
        {
            healSwitch = false;
            other.GetComponent<PlayerController>().healthPoints += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!healSwitch)
            healSwitch = true;
    }
}
