using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaWheel : MonoBehaviour
{
    PlayerController playerController;
    public Slider staminaWheel;
    public Slider staminaUseWheel;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (playerController.useStamina)
        {
            staminaUseWheel.value = playerController.currentStamina / playerController.maxStamina + 0.05f;
        }
        else
        {
            staminaUseWheel.value = playerController.currentStamina / playerController.maxStamina;
        }

        staminaWheel.value = playerController.currentStamina / playerController.maxStamina;
        
        if (staminaWheel.value <= 0)
            staminaUseWheel.value = 0;
    }
}
