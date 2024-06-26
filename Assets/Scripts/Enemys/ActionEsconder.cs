using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class ActionEsconder : MonoBehaviour
{
    private Patrullaje patrullaje;
    public Transform player;
    public NavMeshAgent agent;
    //private AudioListener audioListener;
    public bool detectPlayer;
    
    
    //public float Cont;
    
    private Animator animator;
    [SerializeField]private bool animacionCabar;
    [SerializeField]private string animacionCabarName;

    public LayerMask playerLayerMask;
    [SerializeField] private float radio;


   
    void Start()
    {
        //audioListener = gameObject.GetComponent<AudioListener>();
        patrullaje = GetComponent<Patrullaje>();
        animator = GetComponent<Animator>();
        //animator.SetBool(animacionCabarName,animacionCabar);

    }

    // Update is called once per frame
    void Update()
    {

        detectPlayer = Physics.CheckSphere(this.transform.position, radio, playerLayerMask);
        
        if (detectPlayer)
        {

            //SFXManaguer.instance.PlaySound("SountTerror");
            patrullaje.playerDetect = true;
            animacionCabar = true;
            
            //Cont = 0;

        }

        else if (detectPlayer == false /*|| (detectPlayer == false && Cont >= 5f)*/)
        {
            //SFXManaguer.instance.PlayStop("SountTerror");

            animacionCabar = false;

            patrullaje.playerDetect = false;

            if (patrullaje.patrullando == false)
            {
                patrullaje.StartPatroll();
            }

        }

    }
    public void Animaciones()
    {

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, radio);
    }
}
