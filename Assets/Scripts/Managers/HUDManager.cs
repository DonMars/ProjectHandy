using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    PlayerController playerController;
    
    public GameObject staminaUseWheel;
    public GameObject staminaWheel;
    public GameObject staminaWheelOverlay;

    public GameObject HealthGauge1;
    public GameObject HealthGauge2;
    public GameObject HealthGauge3;
    public GameObject HealthGauge4;
    public GameObject HealthGauge5;

    //public TextMeshProUGUI staminaCounter;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        staminaWheel.SetActive(false);
        staminaUseWheel.SetActive(false);
        staminaWheelOverlay.SetActive(false);

        HealthGauge1.SetActive(false);
        HealthGauge2.SetActive(false);
        HealthGauge3.SetActive(false);
        HealthGauge4.SetActive(false);
        HealthGauge5.SetActive(false);
    }

    void Update()
    {
        //staminaCounter.text = "Stamina: " + playerController.currentStamina.ToString();

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

        if (playerController.healthPoints == 4)
        {
            HealthGauge1.SetActive(true);
            HealthGauge2.SetActive(false);
            HealthGauge3.SetActive(false);
            HealthGauge4.SetActive(false);
            HealthGauge5.SetActive(false);
        }
        else if (playerController.healthPoints == 3)
        {
            HealthGauge1.SetActive(false);
            HealthGauge2.SetActive(true);
            HealthGauge3.SetActive(false);
            HealthGauge4.SetActive(false);
            HealthGauge5.SetActive(false);
        }
        else if (playerController.healthPoints == 2)
        {
            HealthGauge1.SetActive(false);
            HealthGauge2.SetActive(false);
            HealthGauge3.SetActive(true);
            HealthGauge4.SetActive(false);
            HealthGauge5.SetActive(false);
        }
        else if (playerController.healthPoints == 1)
        {
            HealthGauge1.SetActive(false);
            HealthGauge2.SetActive(false);
            HealthGauge3.SetActive(false);
            HealthGauge4.SetActive(true);
            HealthGauge5.SetActive(false);
        }
        else if (playerController.healthPoints <= 0)
        {
            HealthGauge1.SetActive(false);
            HealthGauge2.SetActive(false);
            HealthGauge3.SetActive(false);
            HealthGauge4.SetActive(false);
            HealthGauge5.SetActive(true);
        }
    }
}
