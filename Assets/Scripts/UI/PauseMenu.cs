using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject bestiarioMenu;
    [SerializeField] GameObject fluffInfo;
    [SerializeField] GameObject fluffRockInfo;
    [SerializeField] GameObject fluffFireInfo;
    [SerializeField] GameObject fluffIceInfo;
    [SerializeField] GameObject handyInfo;
    [SerializeField] GameObject fluffPlantInfo;
    [SerializeField] GameObject fluffBombInfo;
    [SerializeField] GameObject fluffMacetaInfo;


    public void Pause()
    {
        
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
        Time.timeScale = 1;
    }
    public void Bestiario()
    {
        bestiarioMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resumebesti()
    {
        bestiarioMenu.SetActive(false);
        pauseMenu.SetActive(false);
        fluffFireInfo.SetActive(false);
        fluffIceInfo.SetActive(false);
        fluffRockInfo.SetActive(false);
        fluffInfo.SetActive(false);
        handyInfo.SetActive(false);
        Time.timeScale = 1;
    }

    public void ResumePause()
    {
        bestiarioMenu.SetActive(false);
        fluffFireInfo.SetActive(false);
        fluffIceInfo.SetActive(false);
        fluffRockInfo.SetActive(false);
        fluffInfo.SetActive(false);
        handyInfo.SetActive(false);

        Time.timeScale = 1;
    }

    public void fluffer()
    {
        fluffInfo.SetActive(true);
        fluffRockInfo.SetActive(false);
        fluffIceInfo.SetActive(false);
        fluffFireInfo.SetActive(false);
        handyInfo.SetActive(false);
        Time.timeScale = 1;
    }

    public void flufferRock()
    {
        fluffRockInfo.SetActive(true);
        fluffInfo.SetActive(false);
        fluffIceInfo.SetActive(false);
        fluffFireInfo.SetActive(false);
        handyInfo.SetActive(false);
        Time.timeScale = 1;
    }

    public void flufferIce()
    {
        fluffIceInfo.SetActive(true);
        fluffRockInfo.SetActive(false);
        fluffInfo.SetActive(false);
        fluffFireInfo.SetActive(false);
        handyInfo.SetActive(false);
        Time.timeScale = 1;
    }

    public void flufferFire()
    {
        fluffFireInfo.SetActive(true);
        fluffIceInfo.SetActive(false);
        fluffRockInfo.SetActive(false);
        fluffInfo.SetActive(false);
        handyInfo.SetActive(false);
        Time.timeScale = 1;
    }

    public void handy()
    {
        handyInfo.SetActive(true);
        fluffIceInfo.SetActive(false);
        fluffRockInfo.SetActive(false);
        fluffFireInfo.SetActive(false);
        fluffInfo.SetActive(false);
        Time.timeScale = 1;
    }

    public void flufferBomb()
    {
        fluffBombInfo.SetActive(true);
        handyInfo.SetActive(false);
        fluffIceInfo.SetActive(false);
        fluffRockInfo.SetActive(false);
        fluffFireInfo.SetActive(false);
        fluffInfo.SetActive(false);
        fluffPlantInfo.SetActive(false);
        fluffMacetaInfo.SetActive(false);
        Time.timeScale = 1;
    }

    public void flufferPlant()
    {
        fluffPlantInfo.SetActive(true);
        handyInfo.SetActive(false);
        fluffIceInfo.SetActive(false);
        fluffRockInfo.SetActive(false);
        fluffFireInfo.SetActive(false);
        fluffInfo.SetActive(false);
        fluffBombInfo.SetActive(false);
        fluffMacetaInfo.SetActive(false);
        Time.timeScale = 1;
    }

    public void flufferMaceta()
    {
        fluffMacetaInfo.SetActive(true);
        handyInfo.SetActive(false);
        fluffIceInfo.SetActive(false);
        fluffRockInfo.SetActive(false);
        fluffFireInfo.SetActive(false);
        fluffInfo.SetActive(false);
        fluffBombInfo.SetActive(false);
        fluffPlantInfo.SetActive(false);
        Time.timeScale = 1;
    }
    public void Map()
    {

        SceneManager.LoadScene("Map");
        Time.timeScale = 1;

    }

}
