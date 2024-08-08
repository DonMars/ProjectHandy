using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu; // Asigna el objeto "Pause Menu" aquí en el Inspector

    private bool isPaused = false;

    void Start()
    {
        // Al inicio del juego, ocultamos y bloqueamos el cursor.
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

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

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Restablece el tiempo de juego
        isPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
