using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    PlayerController playerController;
    
    public GameObject staminaUseWheel;
    public GameObject staminaWheel;
    public GameObject staminaWheelOverlay;

    public GameObject healthGauge1;
    public GameObject healthGauge2;
    public GameObject healthGauge3;
    public GameObject healthGauge4;
    public GameObject healthGauge5;

    public Slider forceGaugeSlider;
    GrabMechanic grabMechanicScript;

    //public TextMeshProUGUI staminaCounter;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        grabMechanicScript = FindObjectOfType<GrabMechanic>();
    }

    void Start()
    {
        staminaWheel.SetActive(false);
        staminaUseWheel.SetActive(false);
        staminaWheelOverlay.SetActive(false);

        healthGauge1.SetActive(false);
        healthGauge2.SetActive(false);
        healthGauge3.SetActive(false);
        healthGauge4.SetActive(false);
        healthGauge5.SetActive(false);
    }

    void Update()
    {
        // Stamina Manager

        if (playerController.currentStamina < playerController.maxStamina)
        {
            staminaWheel.SetActive(true);
            staminaUseWheel.SetActive(true);
            staminaWheelOverlay.SetActive(true);
        }
        else if (playerController.currentStamina == playerController.maxStamina)
        {
            staminaWheel.SetActive(false);
            staminaUseWheel.SetActive(false);
            staminaWheelOverlay.SetActive(false);
        }

        // Life Gauge Manager

        if (playerController.healthPoints == 4)
        {
            healthGauge1.SetActive(true);
            healthGauge2.SetActive(false);
            healthGauge3.SetActive(false);
            healthGauge4.SetActive(false);
            healthGauge5.SetActive(false);
        }
        else if (playerController.healthPoints == 3)
        {
            healthGauge1.SetActive(false);
            healthGauge2.SetActive(true);
            healthGauge3.SetActive(false);
            healthGauge4.SetActive(false);
            healthGauge5.SetActive(false);
        }
        else if (playerController.healthPoints == 2)
        {
            healthGauge1.SetActive(false);
            healthGauge2.SetActive(false);
            healthGauge3.SetActive(true);
            healthGauge4.SetActive(false);
            healthGauge5.SetActive(false);
        }
        else if (playerController.healthPoints == 1)
        {
            healthGauge1.SetActive(false);
            healthGauge2.SetActive(false);
            healthGauge3.SetActive(false);
            healthGauge4.SetActive(true);
            healthGauge5.SetActive(false);
        }
        else if (playerController.healthPoints <= 0)
        {
            healthGauge1.SetActive(false);
            healthGauge2.SetActive(false);
            healthGauge3.SetActive(false);
            healthGauge4.SetActive(false);
            healthGauge5.SetActive(true);
        }

        // Throw Force Gauge Manager
        if (grabMechanicScript.chargeTime > 0)
        {
            forceGaugeSlider.value = grabMechanicScript.chargeTime / grabMechanicScript.maxChargeTime;
        }
        else if (grabMechanicScript.chargeTime <= 0)
        {
            forceGaugeSlider.value = 0;
        }
    }
}
