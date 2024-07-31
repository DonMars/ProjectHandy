using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    bool damageSwitch = true;

    private void OnTriggerEnter(Collider other)
    {
        if (damageSwitch)
        {
            damageSwitch = false;
            other.GetComponent<PlayerController>().healthPoints -= 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!damageSwitch)
            damageSwitch = true;
    }
}
