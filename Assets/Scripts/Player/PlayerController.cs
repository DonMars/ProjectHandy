using Cinemachine.Examples;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using VrGamesDev;


public class PlayerController : MonoBehaviour
{
    public float delayBeforeLoading = 3f;

    [Header("Life")]
    public int healthPoints;
    public int maxHealthPoints = 4;
    public bool canBeDamaged = true;
    public GameObject handMeshRenderer;
    public MeshRenderer handFaceMeshRenderer;

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
    public bool isJumping = false;

    public bool canRun = true;
    public float walkSpeed;
    public float runSpeed;
    public float carryingSpeedDivider;

    public bool isIdle = true;  
    public bool isRunning = false;
    public bool isWalking = false;

    public Transform posicionInicial;

    [Header("Grab Ability")]
    public bool canGrab = true;
    public bool grabSwitch = false;
    public bool isGrabbing = false; // Detecta cuando estás cargando algo
    public float grabbingSpeed;
    GrabMechanic grabMechanic;

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
    public Animator colliderAnimator;
    bool playerDies = false;
    bool deathSwitch = false;

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
        grabMechanic = FindObjectOfType<GrabMechanic>();

        playerRb.freezeRotation = true;

        currentStamina = maxStamina;
        originalStaminaRegenTime = timeBeforeStaminaRegenStarts;

        
    }
    //private void OnEnable()
    //{
    //    if (FindAnyObjectByType<GameManager>().checkPointSave == true && FindAnyObjectByType<GameManager>().continuar == true)
    //    {
    //        this.transform.position = FindAnyObjectByType<GameManager>().PointSpawn;
    //    }
    //}

    void Start()
    {
        // Hide and Lock cursor
        GameManager.Instance.HideAndLockCursor();

        // Set Stamina
        OnStaminaChange?.Invoke(currentStamina);

        StartCoroutine(voyalserver());
    }

    private IEnumerator voyalserver()
    {
        yield return VRG_Remote.IsValid();

        this.maxStamina = VRG_Remote.GetFloat("Float_Stamina");
        this.walkSpeed = VRG_Remote.GetFloat("Float_WalkSpeed");

        yield return null;
    }

    void Update()
    {
        GroundCheck();
        MovementInput();
        SpeedControl();
        StateHandler();
        HandleHealth();
        AnimationHandler();
    }

    void FixedUpdate()
    {
        MovePlayer();
        HandleDrag();
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

    public void GameOver()
    {
        playerDies = true;
        this.enabled = false;

        StartCoroutine(LoadGameOverScene());
    }

    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(delayBeforeLoading);

        SceneManager.LoadScene("GameOver");
    }

    void AnimationHandler()
    {
        animator.SetBool("isIdle", isIdle);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isGrabbing", isGrabbing);

        if (playerDies && !deathSwitch)
        {
            deathSwitch = true;
            animator.ResetTrigger("playerDies");
            animator.SetTrigger("playerDies");
        }
    }

    void StateHandler()
    {
        // State - Running
        if (isGrounded && canRun && Input.GetKey(runKey) && ((Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0) || (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0)))
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
        }

        // State - Idle
        else if (isGrounded && (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0))
        {
            movementState = MovementState.idle;
            isWalking = false;
            isRunning = false;
            isIdle = true;
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

            animator.ResetTrigger("isJumping");
            animator.SetTrigger("isJumping");
            
            colliderAnimator.ResetTrigger("isJumping");
            colliderAnimator.SetTrigger("isJumping");

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
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.35f, groundLayer);
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
        isJumping = true;

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
        if (canBeDamaged && healthPoints > 1)
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
        else if (canBeDamaged && healthPoints == 1)
        {
            healthPoints = 0;
            canBeDamaged = false;
            GameOver();
            return;
        }

        canBeDamaged = false;

        StartCoroutine(DamageCooldown());
    }

    public IEnumerator DamageCooldown()
    {
        handFaceMeshRenderer.enabled = false;
        handMeshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.025f);
        handFaceMeshRenderer.enabled = true;
        handMeshRenderer.SetActive(true);
        yield return new WaitForSeconds(0.025f);
        handFaceMeshRenderer.enabled = false;
        handMeshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.025f);
        handFaceMeshRenderer.enabled = true;
        handMeshRenderer.SetActive(true);
        yield return new WaitForSeconds(0.025f);
        handFaceMeshRenderer.enabled = false;
        handMeshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.025f);
        handFaceMeshRenderer.enabled = true;
        handMeshRenderer.SetActive(true);
        yield return new WaitForSeconds(0.025f);
        handFaceMeshRenderer.enabled = false;
        handMeshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.025f);
        handFaceMeshRenderer.enabled = true;
        handMeshRenderer.SetActive(true);
        yield return new WaitForSeconds(0.025f);
        handFaceMeshRenderer.enabled = false;
        handMeshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        handFaceMeshRenderer.enabled = true;
        handMeshRenderer.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        handFaceMeshRenderer.enabled = false;
        handMeshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        handFaceMeshRenderer.enabled = true;
        handMeshRenderer.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        handFaceMeshRenderer.enabled = false;
        handMeshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        handFaceMeshRenderer.enabled = true;
        handMeshRenderer.SetActive(true);
        yield return new WaitForSeconds(0.08f);
        handFaceMeshRenderer.enabled = false;
        handMeshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.08f);
        handFaceMeshRenderer.enabled = true;
        handMeshRenderer.SetActive(true);
        yield return new WaitForSeconds(0.08f);
        handFaceMeshRenderer.enabled = false;
        handMeshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.09f);
        handFaceMeshRenderer.enabled = true;
        handMeshRenderer.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        handFaceMeshRenderer.enabled = false;
        handMeshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.11f);
        handFaceMeshRenderer.enabled = true;
        handMeshRenderer.SetActive(true);
        yield return new WaitForSeconds(0.13f);
        handFaceMeshRenderer.enabled = false;
        handMeshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        handFaceMeshRenderer.enabled = true;
        handMeshRenderer.SetActive(true);

        canBeDamaged = true;
    }
}
