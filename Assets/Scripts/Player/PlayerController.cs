using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [Header("Life")]
    public int healthPoints;
    public int maxHealthPoints = 4;
    public bool canBeDamaged = true;
    public SkinnedMeshRenderer handMeshRenderer;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode grabKey = KeyCode.Mouse0;
    public KeyCode cancelGrabKey = KeyCode.Mouse1;

    [Header("Movement")]
    public bool canMove = true;
    public float movementSpeed;
    public float groundDrag;

    public bool canJump = true;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool jumpReady = true;
    public AudioSource jumpSound;

    public bool canRun = true;
    public float walkSpeed;
    public float runSpeed;
    public float carryingSpeedDivider;

    public bool isIdle = true;
    public bool isRunning = false;
    public bool isWalking = false;

    [Header("Grab Ability")]
    public bool canGrab = true;
    public bool grabSwitch = false;
    public bool isGrabbing = false; // Detecta cuando estás cargando algo
    public float grabbingSpeed;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundLayer;
    bool isGrounded = false;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    RaycastHit slopeHit;
    bool exitingSlope;

    [Header("Stamina")]
    public bool useStamina = true;
    public float maxStamina = 100;
    public float staminaUseMultiplier = 5;
    public float timeBeforeStaminaRegenStarts = 3;
    public float depletedStaminaRegenTime = 6;
    public float staminaValueIncrement = 2;
    public float staminaTimeIncrement = 0.1f;
    public float currentStamina;
    Coroutine regeneratingStamina;
    public static Action<float> OnStaminaChange;
    public float originalStaminaRegenTime;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 movementDirection;
    Vector3 movementOrientation;

    public Rigidbody playerRb;
    Camera mainCamera;

    public MovementState movementState;

    public ParticleSystem dustParticles;
    public ParticleSystem dustParticlesRunning;
    public ParticleSystem dustParticlesLanding;
    public ParticleSystem hurtGFX;
    public AudioSource hurtSFX1;
    public AudioSource hurtSFX2;
    public Animator staminaUseAnimation;

    [Header("Animator")]
    public Animator animator;

    public enum MovementState
    {
        idle,
        walking,
        running,
        air
    }

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();

        playerRb.freezeRotation = true;

        currentStamina = maxStamina;
        originalStaminaRegenTime = timeBeforeStaminaRegenStarts;
    }

    void Start()
    {
        // Hide and Lock cursor
        GameManager.Instance.HideAndLockCursor();

        // Set Stamina
        OnStaminaChange?.Invoke(currentStamina);
    }

    void Update()
    {
        GroundCheck();
        MovementInput();
        SpeedControl();
        StateHandler();
        HandleDrag();
        HandleHealth();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void HandleHealth()
    {
        if (healthPoints > maxHealthPoints)
            healthPoints = maxHealthPoints;

        if (healthPoints <= 0)
        {
            healthPoints = 0;
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Mr. Handy is DEAD! Game Over");
    }

    void StateHandler()
    {
        // State - Running
        if (isGrounded && canRun && Input.GetKey(runKey))
        {
            movementState = MovementState.running;
            movementSpeed = runSpeed;
            isIdle = false;
            isWalking = false;
            isRunning = true;
        }

        // State - Walking
        else if (isGrounded && canMove && ((Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0) || (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0)))
        {
            movementState = MovementState.walking;
            movementSpeed = walkSpeed;
            isIdle = false;
            isRunning = false;
            isWalking = true;
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);
        }

        // State - Idle
        else if (isGrounded && (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0))
        {
            movementState = MovementState.idle;
            isWalking = false;
            isRunning = false;
            isIdle = true;
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
        }

        // State - Air
        else
        {
            movementState = MovementState.air;
            isWalking = false;
            isRunning = false;
            isIdle = false;
        }
    }

    void MovementInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(verticalInput) > 0.1f || Mathf.Abs(horizontalInput) > 0.1f)
        {
            movementOrientation = (orientation.forward * verticalInput + orientation.right * horizontalInput).normalized;

            if (isGrounded && !isRunning)
                dustParticles.Play();
            else if (isGrounded && isRunning)
                dustParticlesRunning.Play();
        }

        // Jump
        if (Input.GetKey(jumpKey) && canJump && jumpReady && isGrounded)
        {
            jumpReady = false;
            jumpSound.pitch = Random.Range(1.2f, 1.6f);
            jumpSound.Play();
            dustParticlesLanding.Play();
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    void MovePlayer()
    {
        // Calculate movement direction
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // On slope
        if (canMove && OnSlope() && !exitingSlope)
        {
            playerRb.AddForce(GetSlopeMovementDirection() * movementSpeed * 20f, ForceMode.Force);

            if (playerRb.velocity.y > 0)
                playerRb.AddForce(Vector3.down * 1f, ForceMode.Force);
        }

        // On ground
        else if (canMove && isGrounded && isGrabbing)
        {
            playerRb.AddForce(movementDirection.normalized * (movementSpeed / carryingSpeedDivider) * 10f, ForceMode.Force);
        }
        else if (canMove && isGrounded)
        {
            playerRb.AddForce(movementDirection.normalized * movementSpeed * 10f, ForceMode.Force);
        }

        // In air
        else if (canMove && !isGrounded && isGrabbing)
        {
            playerRb.AddForce(movementDirection.normalized * (movementSpeed / carryingSpeedDivider) * 10f * airMultiplier, ForceMode.Force);
        }
        else if (canMove && !isGrounded)
        {
            playerRb.AddForce(movementDirection.normalized * movementSpeed * 10f * airMultiplier, ForceMode.Force);


        }

        // Turn Gravity off on slopes
        playerRb.useGravity = !OnSlope();

        // Using Stamina
        if (useStamina)
            HandleStamina();
    }
    private void GroundCheck()
    {
        // Ground Check
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.35f, groundLayer);
        isGrounded = Physics.Raycast(transform.position + new Vector3(-.2f,0,0), Vector3.down, playerHeight * 0.5f + 0.35f, groundLayer);
        isGrounded = Physics.Raycast(transform.position + new Vector3(.2f,0,0), Vector3.down, playerHeight * 0.5f + 0.35f, groundLayer);
    }

    bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    Vector3 GetSlopeMovementDirection()
    {
        return Vector3.ProjectOnPlane(movementDirection, slopeHit.normal).normalized;
    }

    private void HandleDrag()
    {
        // Drag Handle
        if (isGrounded)
            playerRb.drag = groundDrag;
        else
            playerRb.drag = 0;
    }

    private void SpeedControl()
    {
        // Limit speed on slope
        if (OnSlope() && !exitingSlope)
        {
            if (playerRb.velocity.magnitude > movementSpeed)
                playerRb.velocity = playerRb.velocity.normalized * movementSpeed;
        }
        // Limit speed on ground or in air
        else
        {
            Vector3 flatVelocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

            // Limit velocity if needed
            if (flatVelocity.magnitude > movementSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * movementSpeed;
                playerRb.velocity = new Vector3(limitedVelocity.x, playerRb.velocity.y, limitedVelocity.z);
            }
        }
    }

    void Jump()
    {
        exitingSlope = true;

        // Reset y velocity
        playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

        // Perform Jump
        if (isGrabbing)
            playerRb.AddForce(transform.up * (jumpForce - (carryingSpeedDivider * 2)), ForceMode.Impulse);
        else
            playerRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        jumpReady = true;
        exitingSlope = false;
    }

    private void HandleStamina()
    {
        if (isRunning && movementDirection != Vector3.zero)
        {
            staminaUseAnimation.SetBool("staminaUse", true);

            if (regeneratingStamina != null)
            {
                StopCoroutine(regeneratingStamina);
                regeneratingStamina = null;
            }

            currentStamina -= staminaUseMultiplier * Time.deltaTime;

            if (currentStamina <= 0)
            {
                canRun = false;
            }

            if (currentStamina < 10)
            {
                timeBeforeStaminaRegenStarts = depletedStaminaRegenTime;
            }

            if (currentStamina > 10)
            {
                timeBeforeStaminaRegenStarts = originalStaminaRegenTime;
            }

            OnStaminaChange?.Invoke(currentStamina);
        }

        if (!isRunning && currentStamina < maxStamina && regeneratingStamina == null)
        {
            staminaUseAnimation.SetBool("staminaUse", false);
            regeneratingStamina = StartCoroutine(RegenerateStamina());
        }
    }

    private IEnumerator RegenerateStamina()
    {
        yield return new WaitForSeconds(timeBeforeStaminaRegenStarts);
        WaitForSeconds timeToWait = new WaitForSeconds(staminaTimeIncrement);

        while (currentStamina < maxStamina)
        {
            if (currentStamina > 0)
                canRun = true;

            currentStamina += staminaValueIncrement;

            if (currentStamina > maxStamina)
                currentStamina = maxStamina;

            OnStaminaChange?.Invoke(currentStamina);

            yield return timeToWait;
        }

        regeneratingStamina = null;
    }

    public void ApplyDamage()
    {
        if (canBeDamaged && healthPoints > 0)
        {
            healthPoints--;
            hurtGFX.Play();

            int chance = Random.Range(1, 3);

            if (chance == 1)
            {
                hurtSFX1.pitch = Random.Range(.8f, 1);
                hurtSFX1.Play();
            }
            else if (chance == 2)
            {
                hurtSFX2.pitch = Random.Range(.8f, 1);
                hurtSFX2.Play();
            }
        }
        else if (canBeDamaged && healthPoints <= 0)
        {
            healthPoints = 0;
            GameOver();
        }

        canBeDamaged = false;

        StartCoroutine(DamageCooldown());
    }

    public IEnumerator DamageCooldown()
    {
        handMeshRenderer.enabled = false;
        yield return new WaitForSeconds(0.025f);
        handMeshRenderer.enabled = true;
        yield return new WaitForSeconds(0.025f);
        handMeshRenderer.enabled = false;
        yield return new WaitForSeconds(0.025f);
        handMeshRenderer.enabled = true;
        yield return new WaitForSeconds(0.025f);
        handMeshRenderer.enabled = false;
        yield return new WaitForSeconds(0.025f);
        handMeshRenderer.enabled = true;
        yield return new WaitForSeconds(0.025f);
        handMeshRenderer.enabled = false;
        yield return new WaitForSeconds(0.025f);
        handMeshRenderer.enabled = true;
        yield return new WaitForSeconds(0.025f);
        handMeshRenderer.enabled = false;
        yield return new WaitForSeconds(0.05f);
        handMeshRenderer.enabled = true;
        yield return new WaitForSeconds(0.05f);
        handMeshRenderer.enabled = false;
        yield return new WaitForSeconds(0.05f);
        handMeshRenderer.enabled = true;
        yield return new WaitForSeconds(0.05f);
        handMeshRenderer.enabled = false;
        yield return new WaitForSeconds(0.05f);
        handMeshRenderer.enabled = true;
        yield return new WaitForSeconds(0.08f);
        handMeshRenderer.enabled = false;
        yield return new WaitForSeconds(0.08f);
        handMeshRenderer.enabled = true;
        yield return new WaitForSeconds(0.08f);
        handMeshRenderer.enabled = false;
        yield return new WaitForSeconds(0.09f);
        handMeshRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        handMeshRenderer.enabled = false;
        yield return new WaitForSeconds(0.11f);
        handMeshRenderer.enabled = true;
        yield return new WaitForSeconds(0.13f);
        handMeshRenderer.enabled = false;
        yield return new WaitForSeconds(0.05f);
        handMeshRenderer.enabled = true;

        canBeDamaged = true;
    }
}
