using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.ShowAndUnlockCursor();
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Nivel Final 3");
    }

    public void Bestiario()
    {
        SceneManager.LoadSceneAsync("Galeria");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
