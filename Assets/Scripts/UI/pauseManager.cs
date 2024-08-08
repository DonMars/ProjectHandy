using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu; // Asigna el objeto "Pause Menu" aquí en el Inspector

    private bool isPaused = false;

    void Update()
    {
        // Verifica si la tecla "P" ha sido presionada
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Detiene el tiempo de juego
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Restablece el tiempo de juego
        isPaused = false;
    }
}
