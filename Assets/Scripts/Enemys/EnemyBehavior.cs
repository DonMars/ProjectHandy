using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    //public Animator spybotAnimator;
    //public GameObject explosionVFX;
    //public AudioSource hitSFX1;
    //public AudioSource hitSFX2;
    //public AudioSource hitSFX3;

    [Header("Initialization")]
    public float randomSpeedMin;
    public float randomSpeedMax;


    [Header("Detection")]
    public float detectionRadius = 5;
    public LayerMask playerLayer;
    [SerializeField] private bool aware;
    bool enemyCall = false;
    bool calledSwitch = false;
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
    
    [Header("Collision Damage")]
    public bool dealsOnCollisionDamage = false;
    public int collisionDamageRate = 6;
    public int collisionDamageMin = 1;
    public int collisionDamageMax = 2;
    int collisionDamage;

    Rigidbody rb;
    //EnemyHealth enemyHealth;

    void Start()
    {
        if(GetComponent<NavMeshAgent>() != null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        if(GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        }


        //enemyHealth = GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = Random.Range(randomSpeedMin, randomSpeedMax);
    }

    void Update()
    {
        // Player Detect
        if (Physics.CheckSphere(transform.position, detectionRadius, playerLayer))
        {
            aware = true;
        }
        else
        {
            aware= false;
        }
            

        if (aware)
        {
            
            agent.isStopped = true;

            if(GetComponent<ActionAtack>() != null)
            {
                GetComponent<ActionAtack>().detectPlayer = true;
               
            }
            if(GetComponent<ActionEsconder>() != null)
            {
                GetComponent<ActionEsconder>().detectPlayer = true;
            }


            //enemyCall = true;
            //target = player.position;
            //agent.SetDestination(target);
            ////spybotAnimator.SetBool("isWalking", true);
            //rb.velocity = Vector3.zero;
        }

        //Patrolling
        if (agent.remainingDistance <= agent.stoppingDistance || !aware || !patrolSwitch)
        {
            //agent.isStopped = false;
            if (GetComponent<ActionAtack>() != null)
            {
                GetComponent<ActionAtack>().detectPlayer = false;

            }
            if(GetComponent<ActionEsconder>() != null)
            {
                GetComponent<ActionEsconder>().detectPlayer = false;
            }
            Vector3 point;
            patrolRange = Random.Range(patrolRangeMin, patrolRangeMax);
            //spybotAnimator.SetBool("isWalking", true);

            if (RandomPoint(centrePoint.position, patrolRange, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
                StartCoroutine(PatrolWait());
                //spybotAnimator.SetBool("isWalking", false);
                patrolSwitch = true;
            }
        }

        // Damage Detect
        //if (enemyHealth.health < enemyHealth.startingHealth)
        //{
        //    aware = true;
        //}


    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * patrolRange;
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
        yield return new WaitForSeconds(Random.Range(patrolWaitTimeMin, patrolWaitTimeMax+1));
        patrolSwitch = false;
    }


    //public void InstantiateExplosion()
    //{
    //    Instantiate(explosionVFX.gameObject, transform.position, Quaternion.identity);
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if(other.CompareTag("Enemy") && enemyCall && !calledSwitch)
    //    {
    //        calledSwitch = true;
    //        other.GetComponent<EnemyBehavior>().aware = true;
    //    }
    //}

    //private void OnCollisionStay(Collision collision)
    //{
    //    if(collision.collider.CompareTag("Player") && dealsOnCollisionDamage)
    //    {
    //        int chance = Random.Range(1, collisionDamageRate);

    //        if (chance == 1)
    //        {
    //            int chance2 = Random.Range(1, 4);

    //            if (chance2 == 1)
    //            {
    //                hitSFX1.pitch = Random.Range(0.9f, 1.2f);
    //                hitSFX1.Play();
    //            }
    //            else if (chance2 == 2)
    //            {
    //                hitSFX2.pitch = Random.Range(0.9f, 1.2f);
    //                hitSFX2.Play();
    //            }
    //            else if (chance2 == 3)
    //            {
    //                hitSFX3.pitch = Random.Range(0.8f, 1.1f);
    //                hitSFX3.Play();
    //            }

    //            collisionDamage = Random.Range(collisionDamageMin, collisionDamageMax+1);
    //            //FirstPersonController.OnTakeDamage(collisionDamage);
    //        }
    //    }
    //}

    public void ReAsignarAgent()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, detectionRadius);
    }
}
