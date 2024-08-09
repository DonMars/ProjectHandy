using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class ActionAtack : MonoBehaviour
{
    private Patrullaje patrullaje;
    private Transform player;
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


    //private Animator animator;
    [SerializeField] private bool animacionAtack;
    [SerializeField] private string animacionAtackName;



    // Start is called before the first frame update
    void Start()
    {
        //audioListener = gameObject.GetComponent<AudioListener>();
        patrullaje = FindAnyObjectByType<Patrullaje>();
        //animator= GetComponent<Animator>();
        
        agent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    private bool Atacando;
    private bool Entra;
    //private bool Conin;
    [SerializeField] private float Contt;
    [SerializeField] private float forcePush;
    private bool Atack;
    void Update()
    {
        //animator.SetBool(animacionAtackName, animacionAtack);

        
        if (detectPlayer == false)
        {

            //Cont += Time.deltaTime;
            Contt = 0;
        }
        
        if (detectPlayer == true)
        {

            //SFXManaguer.instance.PlaySound("SountTerror");
            
            //patrullaje.playerDetect = true;
            transform.LookAt(player.position);

            Contt += Time.deltaTime;
            

            if (Contt >= 4)
            {
                Contt = 0;
                animacionAtack = true;
                GetComponent<Rigidbody>().AddForce(transform.forward*forcePush,ForceMode.Impulse);
                Atack = true;
            }
            
            

        }

        //else if ((detectPlayer == false && Vector3.Distance(transform.position, ultimatePosition) <= 3) || (detectPlayer == false && Cont >= 5f))
        //{
        //    //SFXManaguer.instance.PlayStop("SountTerror");
        //    Entra = true;
        //    Atacando = false;
        //    patrullaje.playerDetect = false;
        //    animacionAtack= false;
        //    if (patrullaje.patrullando == false)
        //    {
        //        patrullaje.StartPatroll();
        //    }

        //}

    }

    public void ReAsignarAgent()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" && Atack == true)
        {
            collision.transform.GetComponent<PlayerController>().healthPoints--;
        }
        
        
    }
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(this.transform.position, radio);
    //}
    
}
