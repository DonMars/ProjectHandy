using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quemar : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private string nameAnim;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void efectoCillision()
    {
        animator.Play(nameAnim);
        Destroy(this.gameObject, 3f);
    }
}
