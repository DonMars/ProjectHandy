using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;

public class MainMenu : MonoBehaviour
{
    public string menu = "main menu";

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
        // Cacas Recogidas
        CacasRecogidas CacasRecogidas = new CacasRecogidas
        {
            myFloat = GameManager.Instance.goldenPoop
        };

        Debug.Log(CacasRecogidas.ToString());
        AnalyticsService.Instance.RecordEvent(CacasRecogidas);

        // Cacas Lanzadas
        CacasArrojadas CacasArrojadas = new CacasArrojadas

        {
            myFloat2 = GameManager.Instance.cacasLanzadas
        };

        Debug.Log(CacasArrojadas.ToString());
        AnalyticsService.Instance.RecordEvent(CacasArrojadas);

        // Tarjetas Desbloqueadas
        TarjetasDesbloqueadas TarjetasDesbloqueadas = new TarjetasDesbloqueadas

        {
            myFloat3 = GameManager.Instance.goldenPoop
        };

        Debug.Log(CacasArrojadas.ToString());
        AnalyticsService.Instance.RecordEvent(CacasArrojadas);

        Application.Quit();
    }

    public void MainMe()
    {
        SceneManager.LoadScene(menu);
    }
}
