using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    bool damageSwitch = true;
    PlayerController playerController;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (damageSwitch && playerController.canBeDamaged && other.CompareTag("Player"))
        {
            damageSwitch = false;
            FindAnyObjectByType<PlayerController>().ApplyDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!damageSwitch)
            damageSwitch = true;
    }
}
