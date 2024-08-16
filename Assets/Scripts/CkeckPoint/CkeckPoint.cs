using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CkeckPoint : MonoBehaviour
{
    GameManager gameManager;

    public Transform pointSpawnCheck;
    public Transform newPointSpawnCheck;

    public Animator checkpointAnimation;
    public AudioSource checkpointSFX;
    public ParticleSystem checkpointParticle;

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

            other.GetComponent<PlayerController>().healthPoints = other.GetComponent<PlayerController>().maxHealthPoints;

            if (gameManager.pointSpawn != newPointSpawnCheck.transform.position)
            {
                checkpointAnimation.ResetTrigger("checkpoint");
                checkpointAnimation.SetTrigger("checkpoint");
                checkpointSFX.Play();
                checkpointParticle.Play();
            }
        }
    }
}
