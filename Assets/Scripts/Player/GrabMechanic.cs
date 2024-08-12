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

    [Header("Leap Mechanic")]
    public bool isLeaping = false;

    public Transform grabPoint;
    bool canThrow = false;
    PlayerController player;
    Rigidbody playerRb;
    Grabbable grabbable;
    Rigidbody grabbableRb;
    public bool grabbing = false;

    public LineRenderer trajectoryProjection;

    float holdStartTime;

    public GameObject maxForceSignal;

    public AudioSource chargingThrowSFX;
    public AudioSource throwSFX1;
    public AudioSource throwSFX2;
    public AudioSource throwSFX3;

    Grabbable grabbableLocal;

    public Animator playerAnimator;

    //public Animator playerAnimator;

    void Awake()
    {
        player = GetComponentInParent<PlayerController>();
        playerRb = GetComponentInParent<Rigidbody>();
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
        if (grabbing && player.canGrab && !player.isGrabbing && !player.isRunning || isLeaping)
        {
            grabbing = false;

            playerAnimator.SetTrigger("grabAttempt");
            playerAnimator.ResetTrigger("grabAttempt");

            if (grabbable == null) // If not grabbing, try to grab
            {
                playerAnimator.SetTrigger("grabAttempt");
                playerAnimator.ResetTrigger("grabAttempt");

                if (other.TryGetComponent(out grabbable))
                {
                    grabbableLocal = other.GetComponent<Grabbable>();
                    grabbableRb = grabbable.GetComponent<Rigidbody>();
                    grabbable.Grab(grabPoint);
                    player.isGrabbing = true;
                    holdStartTime = Time.time;

                    Debug.Log("GRABBING");

                    if (grabbable.GetComponent<Efect>() != null)
                    {
                        grabbable.GetComponent<Efect>().enMano = true;
                    }

                    StartCoroutine("ThrowCooldown");
                }
            }
        }

        if (isCharging)
        {
            ChargeThrow();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(player.grabKey) && player.canGrab && !player.isGrabbing && !player.isRunning || isLeaping)
        {
            grabbing = true;
            
        }
        // Leap Ability
        if (Input.GetKeyDown(player.grabKey) && player.canGrab && player.isRunning && !player.isGrabbing && (player.movementSpeed == player.runSpeed))
        {
            playerRb.AddForce((transform.forward + new Vector3(0, 0.2f, 0)) * 35f, ForceMode.Impulse);
            player.currentStamina -= 20;

            playerAnimator.SetTrigger("grabAttempt");
            playerAnimator.ResetTrigger("grabAttempt");

            isLeaping = true;
            player.enabled = false;
            StartCoroutine(LeapRecover());
        }

        // Throw
        if (Input.GetKeyUp(player.grabKey) && isCharging)
            {
            Debug.Log("THROWING");

            if (grabbableLocal.GetComponent<Efect>() != null)
            {
                grabbableLocal.GetComponent<Efect>().enMano = false;
                grabbableLocal.GetComponent<Efect>().Arrojado = true;
            }

            grabbableLocal.particles.Play();

            grabbableRb.isKinematic = false;
            grabbableRb.AddForce((grabPoint.forward + new Vector3(0, 1, 0)) * throwForce * chargeTime, ForceMode.Impulse);

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

            grabbableLocal.grabPoint = null;
            grabbableLocal.transform.parent = null;

            Debug.Log("THREW");

            chargingThrowSFX.Stop();
            chargeTime = 0;
            isCharging = false;
            maxForceSignal.SetActive(false);

            // Hide TrajectoryProjection
            trajectoryProjection.enabled = false;

            float holdDownTime = Time.time - holdStartTime;
            grabbableLocal = null;
            grabbable = null;
            player.isGrabbing = false;
            canThrow = false;
        }
        // Cancel Throw
        else if (Input.GetKeyDown(player.cancelGrabKey) && isCharging)
        {
            chargingThrowSFX.Stop();
            chargeTime = 0;
            isCharging = false;

            if (maxForceSignal.activeInHierarchy)
                maxForceSignal.SetActive(false);

            // Hide TrajectoryProjection
            trajectoryProjection.enabled = false;

            float holdDownTime = Time.time - holdStartTime;
        }
        // Charge Throw
        else if (Input.GetKeyDown(player.grabKey) && player.isGrabbing && canThrow)
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

    private IEnumerator ThrowCooldown()
    {
        yield return new WaitForSeconds(.25f);
        canThrow = true;
    }

    private IEnumerator LeapRecover()
    {
        yield return new WaitForSeconds(0.7f);
        isLeaping = false;
        player.enabled = true;
    }
}
