using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quemar : MonoBehaviour
{

    public Animator animator;
    public AudioSource burningSFX;
    public ParticleSystem particles;

    public void efectoCillision()
    {
        animator.SetTrigger("isBurning");

        burningSFX.Play();
        particles.Play();

        StartCoroutine(ObjectDestroy());
    }

    private IEnumerator ObjectDestroy()
    {
        yield return new WaitForSeconds(5.2f);
        Destroy(this.gameObject);
    }
}
