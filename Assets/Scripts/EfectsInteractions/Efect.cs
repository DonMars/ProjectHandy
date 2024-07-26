using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efect : MonoBehaviour
{
    public bool Arrojado;
    public bool Golpea;
    private Animator animator;
    [SerializeField] private string nameAnim;

    private void OnCollisionEnter(Collision collision)
    {
        animator = collision.gameObject.GetComponent<Animator>();
        if (Arrojado)
        {
            if(collision.transform.tag == "Interactuable")
            {
                animator.Play(nameAnim);
                Destroy(collision.gameObject, 3f);
            }
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        ComprobarArrojado();
    }
    private GrabMechanic grabMechanic;
    private void ComprobarArrojado()
    {
        
    }
}
