using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float ellapsedTime;

    void Update()
    {
        ellapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(ellapsedTime / 60);
        int seconds = Mathf.FloorToInt(ellapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
