using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CkeckPoint : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] private Transform pointSpawnCheck;
    [SerializeField] private Transform newPointSpawnCheck;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            gameManager.PointSpawn = this.transform.position;
            gameManager.checkPointSave = true;
        }
    }
}
