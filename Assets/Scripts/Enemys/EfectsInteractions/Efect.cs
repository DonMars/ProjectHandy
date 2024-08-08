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
    [SerializeField] private bool efectoRoca;

    //private Animator animator;

    [SerializeField] private bool animacionEnMano;
    [SerializeField] private string animacionEnManoName;
    [SerializeField] private bool animacionArrojado;
    [SerializeField] private string animacionArrojadoName;
    private Rigidbody rb;

    [SerializeField] private bool iniciarCont;
    [SerializeField] private bool sinColision;
    private float cont;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
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
                
                if (efectoRoca == true)
                {
                    collision.gameObject.GetComponent<botton>().move = true;
                    
                    
                }

            }
            iniciarCont = true;
            

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        sinColision= false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Arrojado)
        {
            if (other.transform.tag == "Interactuable")
            {
                if (efectoHielo == true)
                {
                    Vector3 contacto = other.ClosestPoint(transform.position);

                    other.gameObject.GetComponent<Hielo>().efectoCillision(contacto);
                    Destroy(gameObject);
                }

                if (efectoNormal == true)
                {
                    other.gameObject.GetComponent<Normal>().move = true;
                    Destroy(gameObject);
                }

            }
            animacionArrojado = false;

        }
        
    }
    //private void Start()
    //{
    //    animator = GetComponent<Animator>();
    //}
    private void Update()
    {
        DesactivarScrips();
        animacionesControl();
        //if (rb.velocity.magnitude == 0 && Arrojado == true)
        //{
        //    Arrojado = false;
        //}
        if(iniciarCont)
        {
            cont += Time.deltaTime;
        }
        if(cont >= 0.5 && sinColision == false)
        {
            Arrojado = false;
            iniciarCont= false;
            cont= 0;
        }
        if(sinColision== true)
        {
            cont = 0;
            iniciarCont= false;
        }

    }
    private void animacionesControl()
    {
        //animator.SetBool(animacionEnManoName, animacionEnMano);
        //animator.SetBool(animacionArrojadoName, animacionArrojado);

        if(Arrojado)
        {
            animacionArrojado = true;
            animacionEnMano= false;
            //this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        if(Arrojado == false)
        {
            animacionArrojado= false;
        }
    }
   
    private void DesactivarScrips()
    {
        if(enMano == true)
        {
            animacionEnMano = true;
            if(GetComponent<ActionAtack>()!=null)
            {
                GetComponent<ActionAtack>().enabled = false;
            }
            if(GetComponent<ActionEsconder>() != null)
            {
                GetComponent<ActionEsconder>().enabled = false;
            }
            //this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

            Destroy(GetComponent<Patrullaje>());

            GetComponent<NavMeshAgent>().enabled = false;

            //animacionArrojado = true;
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

    private void OnTransformParentChanged()
    {
        
    }
}
