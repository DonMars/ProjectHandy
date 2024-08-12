using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
     [Header("Initialization")]
    public float randomSpeedMin;
    public float randomSpeedMax;

    [Header("Detection")]
    public float detectionRadius = 5;
    public LayerMask playerLayer;
    [SerializeField] private bool aware;
    Transform player;
    Vector3 target;

    [Header("Patrolling")]
    public float patrolRangeMin;
    public float patrolRangeMax;
    public int patrolWaitTimeMin;
    public int patrolWaitTimeMax;
    public Transform centrePoint;
    NavMeshAgent agent;
    float patrolRange;
    bool patrolSwitch = false;

    [Header("Animations")]
    public Animator animator; // Referencia al Animator del enemigo
    public string patrolAnimation = "Patrolling"; // Nombre del trigger de la animación de patrullaje
    public string alertAnimation = "Alert"; // Nombre del trigger de la animación de alerta

    void Start()
    {
        if (GetComponent<NavMeshAgent>() != null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = Random.Range(randomSpeedMin, randomSpeedMax);
        SetAnimationState("Patrolling"); // Empezamos en patrullaje
    }

    void Update()
    {
        //if (GetComponent<NavMeshAgent>() != null)
        //{
        //    agent = GetComponent<NavMeshAgent>();
        //}
        // Detección del Jugador
        if (Physics.CheckSphere(transform.position, detectionRadius, playerLayer))
        {
            aware = true;
        }
        else
        {
            aware = false;
        }

        if (aware)
        {
            // El enemigo ha detectado al jugador
            agent.isStopped = true;
            SetAnimationState("Alert"); // Cambia a la animación de alerta
            // Aquí podrías añadir la lógica para que el enemigo ejecute otro script para atacar o seguir al jugador
            if(GetComponent<ActionAtack>() != null)
            {
                GetComponent<ActionAtack>().detectPlayer = true;
            }
            if (GetComponent<ActionEsconder>() != null)
            {
                GetComponent<ActionEsconder>().detectPlayer = true;
            }


        }
        else
        {
            // El enemigo no detecta al jugador, continua patrullando
            if (GetComponent<ActionAtack>() != null)
            {
                GetComponent<ActionAtack>().detectPlayer = false;
            }
            if (GetComponent<ActionEsconder>() != null)
            {
                GetComponent<ActionEsconder>().detectPlayer = false;
            }
            if (!patrolSwitch)
            {
                agent.isStopped = false;
                SetAnimationState("Patrolling"); // Cambia a la animación de patrullaje
                Vector3 point;
                patrolRange = Random.Range(patrolRangeMin, patrolRangeMax);

                if (RandomPoint(centrePoint.position, patrolRange, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                    agent.SetDestination(point);
                    StartCoroutine(PatrolWait());
                    patrolSwitch = true;
                }
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    IEnumerator PatrolWait()
    {
        yield return new WaitForSeconds(Random.Range(patrolWaitTimeMin, patrolWaitTimeMax + 1));
        patrolSwitch = false;
    }

    private void SetAnimationState(string state)
    {
        if (animator != null)
        {
            animator.SetTrigger(state);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, detectionRadius);
    }
}
