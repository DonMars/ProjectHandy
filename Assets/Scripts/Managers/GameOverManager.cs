using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Continue()
    {
        
    }

    // Update is called once per frame
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
