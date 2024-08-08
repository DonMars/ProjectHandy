using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestiaryManager : MonoBehaviour
{
    public static BestiaryManager Instance;

    [SerializeField] GameObject fluffCard;
    [SerializeField] GameObject fluffRockCard;
    [SerializeField] GameObject fluffFireCard;
    [SerializeField] GameObject fluffIceCard;
    [SerializeField] GameObject handyCard;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockBestiaryEntry()
    {

        // Activa las tarjetas e información basadas en la cantidad de recolectables
        if (GameManager.Instance.goldenPoop >= 1)
        {
            fluffCard.SetActive(true);
        }
        if (GameManager.Instance.goldenPoop >= 2)
        {
            fluffRockCard.SetActive(true);
        }
        if (GameManager.Instance.goldenPoop >= 3)
        {
            fluffFireCard.SetActive(true);
        }
        if (GameManager.Instance.goldenPoop >= 4)
        {
            fluffIceCard.SetActive(true);
        }
        if (GameManager.Instance.goldenPoop >= 5)
        {
            handyCard.SetActive(true);
        }
    }
}
