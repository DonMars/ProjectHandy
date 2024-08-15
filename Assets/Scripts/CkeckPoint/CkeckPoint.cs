using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CkeckPoint : MonoBehaviour
{
    GameManager gameManager;

    public Transform pointSpawnCheck;
    public Transform newPointSpawnCheck;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            gameManager.pointSpawn = newPointSpawnCheck.transform.position;
            gameManager.checkPointSave = true;
        }
    }
}
