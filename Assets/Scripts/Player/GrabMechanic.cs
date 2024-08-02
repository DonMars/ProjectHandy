using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMechanic : MonoBehaviour
{
    [Header("Throw Mechanic")]
    float throwForce = 5f;
    public float chargeTime = 0f;
    public float maxChargeTime = 3f;
    bool isCharging;
    Vector3 throwDirection = new Vector3(0,1,0);
    
    public Transform grabPoint;
    PlayerController player;
    Grabbable grabbable;
    Rigidbody grabbableRb;

    public LineRenderer trajectoryProjection;

    float holdStartTime;

    public GameObject maxForceSignal;

    public AudioSource chargingThrowSFX;
    public AudioSource throwSFX1;
    public AudioSource throwSFX2;
    public AudioSource throwSFX3;

    void Awake()
    {
        player = GetComponentInParent<PlayerController>();
    }

    private void Start()
    {
        maxForceSignal.SetActive(false);
    }

    public struct ThrowableProperties
    {
        public Vector3 direction;
        public Vector3 initialPosition;
        public float initialSpeed;
        public float mass;
        public float drag;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(player.grabKey) && player.canGrab && !player.isGrabbing)
        {
            if (grabbable == null) // If not grabbing, try to grab
            {
                if (other.TryGetComponent(out grabbable))
                {
                    grabbableRb = grabbable.GetComponent<Rigidbody>();
                    grabbable.Grab(grabPoint);
                    player.isGrabbing = true;
                    holdStartTime = Time.time;

                    Debug.Log("GRABBING");
                    if(grabbable.GetComponent<Efect>() != null)
                    {
                        grabbable.GetComponent<Efect>().enMano = true;
                    }
                    
                }
            }

        }
        else if (Input.GetKeyDown(player.grabKey) && player.isGrabbing)
        {
            chargingThrowSFX.Play();

            isCharging = true;
            chargeTime = 0;
            chargeTime += Time.deltaTime;
            Debug.Log(chargeTime);
            Debug.Log("CHARGING");

            // TrajectoryProjection
            trajectoryProjection.enabled = true;
        }
        
        if (Input.GetKeyUp(player.grabKey) && isCharging)
        {
            Debug.Log("THROWING");

            if(grabbable.GetComponent<Efect>() != null)
            {
                grabbable.GetComponent<Efect>().enMano = false;
                grabbable.GetComponent<Efect>().Arrojado = true;
            }

            other.TryGetComponent(out grabbable);

            grabbableRb.isKinematic = false;
            grabbableRb.AddForce((grabPoint.forward + new Vector3 (0,1,0)) * throwForce * chargeTime, ForceMode.Impulse);

            // Throw SFX
            int chance = Random.Range(1, 4);
            if (chance == 1)
            {
                throwSFX1.Play();
            }
            else if (chance == 2)
            {
                throwSFX2.Play();
            }
            else if (chance == 3)
            {
                throwSFX3.Play();
            }
            
            grabbable.grabPoint = null;
            grabbable.transform.parent = null;

            Debug.Log("THREW");

            chargingThrowSFX.Stop();
            chargeTime = 0;
            isCharging = false;
            maxForceSignal.SetActive(false);

            // Hide TrajectoryProjection
            trajectoryProjection.enabled = false;

            float holdDownTime = Time.time - holdStartTime;
            grabbable = null;
            player.isGrabbing = false;
        }

        if (isCharging)
        {
            ChargeThrow();
        }
    }

    void ChargeThrow()
    {
        chargeTime += Time.deltaTime;

        if (chargeTime >= maxChargeTime)
        {
            chargeTime = maxChargeTime;
            maxForceSignal.SetActive(true);
        }

        Debug.Log(chargeTime);

        // TrajectoryProjection line velocity
        Vector3 lineVelocity = (grabPoint.forward + throwDirection).normalized * Mathf.Min(chargeTime * throwForce, maxChargeTime * 100f);
        ShowTrajectory(grabPoint.position + grabPoint.forward, lineVelocity);
    }

    void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[100];
        trajectoryProjection.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = origin + speed * time + 0.5f * Physics.gravity * time * time;
        }

        trajectoryProjection.SetPositions(points);
    }
}
