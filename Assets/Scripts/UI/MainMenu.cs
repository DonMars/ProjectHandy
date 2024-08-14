using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;

public class MainMenu : MonoBehaviour
{
    public string menu = "main menu";
    CustomEvent_Hakari cacas;
    private void Awake()
    {
        //GameManager.Instance.ShowAndUnlockCursor();
    }

    private void Start()
    {
        // Mostrar el cursor del mouse y desbloquearlo
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        AnalyticsService.Instance.RecordEvent("PlayGame");
        SceneManager.LoadSceneAsync("Nivel Final 4");
    }

    public void Bestiario()
    {
        SceneManager.LoadSceneAsync("Galeria");
    }

    public void Quit()
    {
        cacas.ContarCacas();
        Application.Quit();
    }

    public void MainMe()
    {
        SceneManager.LoadScene(menu);
    }
}
