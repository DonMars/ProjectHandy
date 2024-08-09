using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject bestiarioMenu;
    [SerializeField] GameObject controlesMenu;
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
        SceneManager.LoadScene("MainMenu Final Redux");
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
    public void Controles()
    {
        controlesMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resumebesti()
    {
        DeactivateAllCards();
        pauseMenu.SetActive(false);
        bestiarioMenu.SetActive(false);
        controlesMenu.SetActive(false);

        Time.timeScale = 0;
    }

    public void ResumePause()
    {
        DeactivateAllCards();
        bestiarioMenu.SetActive(false);
        controlesMenu.SetActive(false);


        Time.timeScale = 0;
    }

    public void fluffer()
    {
        DeactivateAllCards();
        fluffInfo.SetActive(true);
        if (GameManager.Instance.goldenPoop >= 10)
        {
            DeactivateAllCards();
            fluffCard.SetActive(true); // Desbloquea la primera tarjeta
        }
        Time.timeScale = 0;
    }

    public void flufferRock()
    {
        DeactivateAllCards();
        fluffRockInfo.SetActive(true);
        if (GameManager.Instance.goldenPoop >= 20)
        {
            DeactivateAllCards();
            fluffRockCard.SetActive(true); // Desbloquea la segunda tarjeta
        }
        Time.timeScale = 0;
    }

    public void flufferFire()
    {

        DeactivateAllCards();
        fluffFireInfo.SetActive(true);
        if (GameManager.Instance.goldenPoop >= 30)
        {
            DeactivateAllCards();
            fluffFireCard.SetActive(true); // Desbloquea la segunda tarjeta
        }
        Time.timeScale = 0;
    }
    public void flufferIce()
    {
        DeactivateAllCards();
        fluffIceInfo.SetActive(true);
        if (GameManager.Instance.goldenPoop >= 40)
        {
            DeactivateAllCards();
            fluffIceCard.SetActive(true); // Desbloquea la segunda tarjeta
        }

        Time.timeScale = 0;
    }


    public void handy()
    {
        DeactivateAllCards();
        handyInfo.SetActive(true);
        if (GameManager.Instance.goldenPoop >= 50)
        {
            DeactivateAllCards();
            handyCard.SetActive(true); // Desbloquea la segunda tarjeta
        }

        Time.timeScale = 0;
    }

    public void flufferBomb()
    {
        DeactivateAllCards();
        fluffBombInfo.SetActive(true);
        Time.timeScale = 0;
    }

    public void flufferPlant()
    {
        DeactivateAllCards();
        fluffPlantInfo.SetActive(true);
        Time.timeScale = 0;
    }

    public void flufferMaceta()
    {
        DeactivateAllCards();
        fluffMacetaInfo.SetActive(true);
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
            fluffCard.SetActive(true); // Desbloquea la primera tarjeta
        }
        if (GameManager.Instance.goldenPoop >= 2)
        {
            fluffRockCard.SetActive(true); // Desbloquea la segunda tarjeta
        }
        if (GameManager.Instance.goldenPoop >= 3)
        {
            fluffFireCard.SetActive(true); // Desbloquea la tercera tarjeta
        }
        if (GameManager.Instance.goldenPoop >= 4)
        {
            fluffIceCard.SetActive(true); // Desbloquea la cuarta tarjeta
        }
        if (GameManager.Instance.goldenPoop >= 5)
        {
            handyCard.SetActive(true); // Desbloquea la quinta tarjeta
        }
    }

    private void DeactivateAllCards()
    {
        // Apaga todas las tarjetas antes de activar la seleccionada
        fluffRockInfo.SetActive(false);
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
    }

}
