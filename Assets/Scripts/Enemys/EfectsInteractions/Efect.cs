using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Efect : MonoBehaviour
{
    public bool Arrojado;
    public bool enMano;
    public bool Golpea;
    //private Animator animator;
    //[SerializeField] private string nameAnim;

    [SerializeField] private bool efectofuego;
    [SerializeField] private bool efectoHielo;
    [SerializeField] private bool efectoNormal;

    private void OnCollisionEnter(Collision collision)
    {
        //animator = collision.gameObject.GetComponent<Animator>();
        if (Arrojado)
        {
            if (collision.transform.tag == "Interactuable")
            {
                if (efectofuego == true)
                {
                    collision.gameObject.GetComponent<Quemar>().efectoCillision();
                    Destroy(gameObject);
                }
                if (efectoHielo == true)
                {
                    transform contacto = collision.GetContact();
                    collision.gameObject.GetComponent<Hielo>().efectoCillision();
                    Destroy(gameObject);
                }

            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Arrojado)
        {
            if (other.transform.tag == "Interactuable")
            {
                
                
                if (efectoNormal == true)
                {
                    other.gameObject.GetComponent<Normal>().move = true;
                    Destroy(gameObject);
                }

            }

        }
    }
    private void Update()
    {
        DesactivarScrips();
    }
   
    private void DesactivarScrips()
    {
        if(enMano == true)
        {
            if(GetComponent<ActionAtack>()!=null)
            {
                GetComponent<ActionAtack>().enabled = false;
            }
            if(GetComponent<ActionEsconder>() != null)
            {
                GetComponent<ActionEsconder>().enabled = false;
            }
            //if (GetComponent<NavMeshAgent>() != null)
            //{

            //}
            Destroy(GetComponent<Patrullaje>());

            GetComponent<NavMeshAgent>().enabled = false;
            //GetComponent<CapsuleCollider>().enabled = false;


        }
        else
        {
            //if (GetComponent<NavMeshAgent>() != null)
            //{
                
            //}

            //GetComponent<NavMeshAgent>().enabled = true;


            //GetComponent<Patrullaje>().enabled = true;
        }


    }
}
