using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFlufferPlatform : MonoBehaviour
{

    public AudioSource icePlatformSFX;

    void Start()
    {
        icePlatformSFX.pitch = Random.Range(0.7f, 1);
        icePlatformSFX.Play();
    }
}
