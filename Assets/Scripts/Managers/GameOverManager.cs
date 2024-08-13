using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public string nivel = "nivel2";
    public string menu = "main menu";

    private void Start()
    {
        // Mostrar el cursor del mouse y desbloquearlo
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Continue()
    {
        //FindAnyObjectByType<GameManager>().continuar = true;
        //FindAnyObjectByType<GameManager>().checkPointSave = true;
        SceneManager.LoadScene(nivel);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(menu);
    }
}
