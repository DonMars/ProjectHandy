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

    PlayerController playerController;

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

    bool damageSwitch = true;
    bool attackSwitch = false;

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
                GetComponent<Rigidbody>().AddForce(transform.forward * forcePush,ForceMode.Impulse);
                Atack = true;
                attackSwitch = true;
                StartCoroutine(AttackReset());
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
        if (collision.transform.tag == "Player")
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();
        }

        if (collision.transform.tag == "Player" && Atack == true && attackSwitch)
        {
            if (damageSwitch && playerController.canBeDamaged)
            {
                damageSwitch = false;
                FindAnyObjectByType<PlayerController>().ApplyDamage();
            }

            StartCoroutine(AttackRestart());
        }
    }

    private IEnumerator AttackRestart()
    {
        yield return new WaitUntil(() => Atack);
        attackSwitch = true;
    }

    private IEnumerator AttackReset()
    {
        yield return new WaitForSeconds(1.2f);
        Atack = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!damageSwitch && collision.transform.tag == "Player")
            damageSwitch = true;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(this.transform.position, radio);
    //}

}
