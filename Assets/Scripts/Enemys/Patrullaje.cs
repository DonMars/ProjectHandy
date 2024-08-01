using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.AI;

public class Patrullaje : MonoBehaviour
{

    [SerializeField] public NavMeshAgent agent;
    public bool playerDetect;



    public bool patrullando;

    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;
    public Vector3 ZonaMin;
    public Vector3 ZonaMax;
    private Vector3 posicionAleatoria;

    //private Animator Animator;

    [SerializeField] private bool activateAnimacionWalk;
    [SerializeField] private string animacionWalkName;
    [SerializeField] private bool activateAnimacionRandom;
    [SerializeField] private string animacionAccionRandomName;
    public bool activateAnimacionArrojado;
    public string animacionAccionArrojadoName;


    private Rigidbody rb;
    void Start()
    {
        IncializarVectores();
        StartCoroutine(Patroll());
        //Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        


    }
    private void Update()
    {
        AnimacionesWalk();
        //Animator.SetBool(animacionWalkName, animacionWalk);
        //Animator.SetBool(animacionAccionRandomName, animacionAccionRandom);
    }

    #region Patrllaje

    public IEnumerator Patroll()
    {
        patrullando = true;
        
        if(RandomNum() == 1)
        {
            agent.SetDestination(PosicionAleatoria());
            Debug.Log(" no esper�");
        }
        else
        {
            if(agent.velocity.magnitude == 0)
            {
                activateAnimacionRandom = true;
            }
            //animacionAccionRandom = true;
            yield return new WaitForSeconds(5);
            Debug.Log("esper�");
            activateAnimacionRandom = false;
        }
        

        yield return new WaitUntil(() => (Vector3.Distance(transform.position, PosicionAleatoria()) <= 0.8) || playerDetect == true);




        if (playerDetect == true)
        {

            patrullando = false;
            StopCoroutine(Patroll());
        }
        else
        {

            StartCoroutine(Patroll());
        }
        //llega al destino

    }
    public void StartPatroll()
    {
        StartCoroutine(Patroll());
    }
    public void StopPatroll()
    {
        StopCoroutine(Patroll());
    }

    #endregion Patrllaje

    #region Randoms
    private void IncializarVectores()
    {
        //ZonaMin = minPos.position;
        //ZonaMax = maxPos.position;
    }
    Vector3 PosicionAleatoria()
    {
        float posX = Random.Range(ZonaMin.x, ZonaMax.x);
        float posy = Random.Range(ZonaMin.y, ZonaMax.y);
        float posz = Random.Range(ZonaMin.z, ZonaMax.z);

        return posicionAleatoria = new Vector3(posX, posy, posz);

    }


    private int RandomNum() // Lo unico que hace es darte un random
    {
        int random = Random.Range(1, 3);
        return random;
    }
    #endregion Randoms

    private void AnimacionesWalk()
    {
        
        if( agent.velocity.magnitude == 0)
        {
            activateAnimacionWalk = false;
        }
        else
        {
            activateAnimacionWalk = true;
        }
    }
}
