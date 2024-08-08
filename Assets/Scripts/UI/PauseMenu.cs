using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

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
    [SerializeField] GameObject fluffCard;
    [SerializeField] GameObject fluffRockCard;
    [SerializeField] GameObject fluffFireCard;
    [SerializeField] GameObject fluffIceCard;
    [SerializeField] GameObject handyCard;


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
        fluffBombInfo.SetActive(false);
        fluffMacetaInfo.SetActive(false);
        fluffPlantInfo.SetActive(false);
        fluffCard.SetActive(false);
        fluffRockCard.SetActive(false);
        fluffFireCard.SetActive(false);
        fluffIceCard.SetActive(false);
        handyCard.SetActive(false);
        
        Time.timeScale = 0;
    }

    public void ResumePause()
    {
        bestiarioMenu.SetActive(false);
        fluffFireInfo.SetActive(false);
        fluffIceInfo.SetActive(false);
        fluffRockInfo.SetActive(false);
        fluffInfo.SetActive(false);
        handyInfo.SetActive(false);
        fluffBombInfo.SetActive(false);
        fluffMacetaInfo.SetActive(false);
        fluffPlantInfo.SetActive(false);
        fluffCard.SetActive(false);
        fluffRockCard.SetActive(false);
        fluffFireCard.SetActive(false);
        fluffIceCard.SetActive(false);
        handyCard.SetActive(false);


        Time.timeScale = 0;
    }

    public void fluffer()
    {
        fluffInfo.SetActive(true);
        fluffRockInfo.SetActive(false);
        fluffIceInfo.SetActive(false);
        fluffFireInfo.SetActive(false);
        handyInfo.SetActive(false);
        fluffBombInfo.SetActive(false);
        fluffMacetaInfo.SetActive(false);
        fluffPlantInfo.SetActive(false);
        fluffCard.SetActive(false);
        fluffRockCard.SetActive(false);
        fluffFireCard.SetActive(false);
        fluffIceCard.SetActive(false);
        handyCard.SetActive(false);
        UnlockBestiaryEntry();
        Time.timeScale = 0;
    }

    public void flufferRock()
    {
        fluffRockInfo.SetActive(true);
        fluffInfo.SetActive(false);
        fluffIceInfo.SetActive(false);
        fluffFireInfo.SetActive(false);
        handyInfo.SetActive(false);
        fluffBombInfo.SetActive(false);
        fluffMacetaInfo.SetActive(false);
        fluffPlantInfo.SetActive(false);
        fluffCard.SetActive(false);
        fluffRockCard.SetActive(false);
        fluffFireCard.SetActive(false);
        fluffIceCard.SetActive(false);
        handyCard.SetActive(false);
        Time.timeScale = 0;
    }

    public void flufferIce()
    {
        fluffIceInfo.SetActive(true);
        fluffRockInfo.SetActive(false);
        fluffInfo.SetActive(false);
        fluffFireInfo.SetActive(false);
        handyInfo.SetActive(false);
        fluffBombInfo.SetActive(false);
        fluffMacetaInfo.SetActive(false);
        fluffPlantInfo.SetActive(false);
        fluffCard.SetActive(false);
        fluffRockCard.SetActive(false);
        fluffFireCard.SetActive(false);
        fluffIceCard.SetActive(false);
        handyCard.SetActive(false);

        Time.timeScale = 0;
    }

    public void flufferFire()
    {
        fluffFireInfo.SetActive(true);
        fluffIceInfo.SetActive(false);
        fluffRockInfo.SetActive(false);
        fluffInfo.SetActive(false);
        handyInfo.SetActive(false);
        fluffBombInfo.SetActive(false);
        fluffMacetaInfo.SetActive(false);
        fluffPlantInfo.SetActive(false);
        fluffCard.SetActive(false);
        fluffRockCard.SetActive(false);
        fluffFireCard.SetActive(false);
        fluffIceCard.SetActive(false);
        handyCard.SetActive(false);

        Time.timeScale = 0;
    }

    public void handy()
    {
        handyInfo.SetActive(true);
        fluffIceInfo.SetActive(false);
        fluffRockInfo.SetActive(false);
        fluffFireInfo.SetActive(false);
        fluffInfo.SetActive(false);
        fluffBombInfo.SetActive(false);
        fluffMacetaInfo.SetActive(false);
        fluffPlantInfo.SetActive(false);
        fluffCard.SetActive(false);
        fluffRockCard.SetActive(false);
        fluffFireCard.SetActive(false);
        fluffIceCard.SetActive(false);
        handyCard.SetActive(false);

        Time.timeScale = 0;
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
        fluffCard.SetActive(false);
        fluffRockCard.SetActive(false);
        fluffFireCard.SetActive(false);
        fluffIceCard.SetActive(false);
        handyCard.SetActive(false);
        Time.timeScale = 0;
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
        fluffCard.SetActive(false);
        fluffRockCard.SetActive(false);
        fluffFireCard.SetActive(false);
        fluffIceCard.SetActive(false);
        handyCard.SetActive(false);
        Time.timeScale = 0;
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
        fluffCard.SetActive(false);
        fluffRockCard.SetActive(false);
        fluffFireCard.SetActive(false);
        fluffIceCard.SetActive(false);
        handyCard.SetActive(false);
        Time.timeScale = 0;
    }
    public void Map()
    {

        SceneManager.LoadScene("Map");
        Time.timeScale = 1;

    }

    public void UnlockBestiaryEntry()
    {

        // Activa las tarjetas e información basadas en la cantidad de recolectables
        if (GameManager.Instance.goldenPoop >= 1)
        {
            fluffCard.SetActive(true);
            fluffInfo.SetActive(false);
            fluffRockInfo.SetActive(false);
            fluffIceInfo.SetActive(false);
            fluffFireInfo.SetActive(false);
            handyInfo.SetActive(false);
            fluffBombInfo.SetActive(false);
            fluffMacetaInfo.SetActive(false);
            fluffPlantInfo.SetActive(false);
            fluffRockCard.SetActive(false);
            fluffFireCard.SetActive(false);
            fluffIceCard.SetActive(false);
            handyCard.SetActive(false);
        }
        if (GameManager.Instance.goldenPoop >= 2)
        {

        }
        if (GameManager.Instance.goldenPoop >= 3)
        {

        }
        if (GameManager.Instance.goldenPoop >= 4)
        {
  
        }
        if (GameManager.Instance.goldenPoop >= 5)
        {

        }
    }
}
