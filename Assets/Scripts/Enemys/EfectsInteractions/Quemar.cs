using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quemar : MonoBehaviour
{

    //private Animator animator;
    [SerializeField] private string nameAnim;
    [SerializeField] private ParticleSystem particles;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void efectoCillision()
    {
        animator.Play(nameAnim);
        particles.Play();
        Debug.Log("Partículas activadas");
        Destroy(this.gameObject, 3f);
    }
}
