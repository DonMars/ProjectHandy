using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CkeckPoint : MonoBehaviour
{
    [SerializeField] private Transform pointSpawnCheck;
    [SerializeField] private Transform newPointSpawnCheck;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            //FindAnyObjectByType<GameManager>().PointSpawn = this.transform.position;
            //FindAnyObjectByType<GameManager>().checkPointSave = true;
        }
    }
}
