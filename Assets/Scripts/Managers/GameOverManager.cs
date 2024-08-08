using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public string nivel = "nivel2";
    public string menu = "main menu";
    
    public void Continue()
    {
        SceneManager.LoadScene(nivel);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(menu);
    }
}
