using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;

    [Header("Movement")]
    public bool canMove = true;
    public float movementSpeed;
    public float groundDrag;

    public bool canJump = true;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool jumpReady = true;

    public bool canRun = true;
    public float walkSpeed;
    public float runSpeed;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundLayer;
    bool isGrounded = false;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    RaycastHit slopeHit;
    bool exitingSlope;


    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 movementDirection;

    Rigidbody playerRb;
    Camera mainCamera;

    public MovementState movementState;

    public enum MovementState
    {
        idle,
        walking,
        running,
        carrying,
        throwing,
        air
    }

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();

        playerRb.freezeRotation = true;
    }

    void Start()
    {
        // Hide and Lock cursor
        GameManager.Instance.HideAndLockCursor();
    }

    void Update()
    {
        GroundCheck();
        MovementInput();
        SpeedControl();
        StateHandler();
        HandleDrag();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void StateHandler()
    {
        // State - Running
        if (isGrounded && canRun && Input.GetKey(runKey))
        {
            movementState = MovementState.running;
            movementSpeed = runSpeed;
        }

        // State - Walking
        else if (isGrounded && canMove && ((Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0) || (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0)))
        {
            movementState = MovementState.walking;
            movementSpeed = walkSpeed;
        }

        // State - Idle
        else if (isGrounded && (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0))
        {
            movementState = MovementState.idle;
        }

        // State - Air
        else
        {
            movementState = MovementState.air;
        }
    }

    void MovementInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Jump
        if (Input.GetKey(jumpKey) && canJump && jumpReady && isGrounded)
        {
            jumpReady = false;
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
        else if (canMove && isGrounded)
            playerRb.AddForce(movementDirection.normalized * movementSpeed * 10f, ForceMode.Force);

        // In air
        else if (canMove && !isGrounded)
            playerRb.AddForce(movementDirection.normalized * movementSpeed * 10f * airMultiplier, ForceMode.Force);

        // Turn Gravity off on slopes
        playerRb.useGravity = !OnSlope();
    }
    private void GroundCheck()
    {
        // Ground Check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
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

        playerRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        jumpReady = true;
        exitingSlope = false;
    }
}
