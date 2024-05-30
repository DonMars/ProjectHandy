using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    PlayerController playerController;

    public TextMeshProUGUI staminaCounter;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        staminaCounter.text = "Stamina: " + playerController.currentStamina.ToString();
    }
}
