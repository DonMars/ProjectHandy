using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quemar : MonoBehaviour
{

    //private Animator animator;
    public ParticleSystem particles;
    public Animator animator;

    public void efectoCillision()
    {
        animator.SetTrigger("isBurning");
        particles.Play();
        Destroy(this.gameObject, 5.2f);
    }
}
