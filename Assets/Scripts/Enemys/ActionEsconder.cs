using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class ActionEsconder : MonoBehaviour
{
    private Patrullaje patrullaje;
    //public Transform player;
    public NavMeshAgent agent;
    //private AudioListener audioListener;
    public bool detectPlayer;
    
    
    //public float Cont;
    
    //private Animator animator;
    [SerializeField]private bool animacionEsconder;
    [SerializeField]private string animacionCabarName;

    public LayerMask playerLayerMask;
    [SerializeField] private float radio;


   
    void Start()
    {
        //audioListener = gameObject.GetComponent<AudioListener>();
        //patrullaje = GetComponent<Patrullaje>();
        //animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        //Animaciones();
        
        if (detectPlayer)
        {

            //SFXManaguer.instance.PlaySound("SountTerror");
            
            animacionEsconder = true;
            
            //Cont = 0;

        }

        else if (detectPlayer == false /*|| (detectPlayer == false && Cont >= 5f)*/)
        {
            //SFXManaguer.instance.PlayStop("SountTerror");

            animacionEsconder = false;

            

            //if (patrullaje.patrullando == false)
            //{
            //    patrullaje.StartPatroll();
            //}

        }

    }
    //public void Animaciones()
    //{
    //    animator.SetBool(animacionCabarName,animacionCabar);
    //}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, radio);
    }
}
