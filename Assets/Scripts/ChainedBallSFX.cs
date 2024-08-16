using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainedBallSFX : MonoBehaviour
{
    public AudioSource chainedBallSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            chainedBallSFX.Play();
    }
}
