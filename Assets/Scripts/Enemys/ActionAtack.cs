using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class ActionAtack : MonoBehaviour
{
    private Patrullaje patrullaje;
    public Transform player;
    public NavMeshAgent agent;
    //private AudioListener audioListener;
    public bool detectPlayer;

    //public float radio1;
    //public float radio2;
    //public float radio3;
    public float Cont;



    public LayerMask playerLayerMask;
    [SerializeField] private float radio;

    public Vector3 ultimatePosition;

    
    private Animator animator;
    [SerializeField] private bool animacionAtack;
    [SerializeField] private string animacionAtackName;



    // Start is called before the first frame update
    void Start()
    {
        //audioListener = gameObject.GetComponent<AudioListener>();
        patrullaje = FindAnyObjectByType<Patrullaje>();
        animator= GetComponent<Animator>();
        //animator.SetBool(animacionAtackName, animacionAtack);
        agent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    private bool Atacando;
    private bool Entra;
    void Update()
    {
        
        detectPlayer = Physics.CheckSphere(this.transform.position, radio, playerLayerMask);
        if (detectPlayer == false)
        {

            Cont += Time.deltaTime;
        }
        
        if (detectPlayer == true)
        {

            //SFXManaguer.instance.PlaySound("SountTerror");
            animacionAtack= true;
            patrullaje.playerDetect = true;
            ultimatePosition = player.position;
            agent.SetDestination(ultimatePosition);
            Cont = 0;
            

        }

        else if ((detectPlayer == false && Vector3.Distance(transform.position, ultimatePosition) <= 3) || (detectPlayer == false && Cont >= 5f))
        {
            //SFXManaguer.instance.PlayStop("SountTerror");
            Entra = true;
            Atacando = false;
            patrullaje.playerDetect = false;
            animacionAtack= false;
            if (patrullaje.patrullando == false)
            {
                patrullaje.StartPatroll();
            }

        }

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.transform.tag == "Player")
    //    {
            
    //    }
    //}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, radio);
    }
    
}
