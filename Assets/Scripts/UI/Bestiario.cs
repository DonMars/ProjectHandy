using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bestiario : MonoBehaviour
{

    public GameObject[] entries;

    public void EnableEntry(int id)
    {
        for (int i = 0; i < entries.Length; i++)
        {
            entries[i].SetActive(false);
        }
        entries[id].SetActive(true);    
    }
}
