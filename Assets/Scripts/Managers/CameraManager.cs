using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("References")]
    public Transform lookDirection;
    public Transform player;
    public Transform playerModel;
    public Rigidbody playerRb;

    public float rotationSpeed;

    public CameraMode currentMode;
    public Transform combatLookAt;

    public enum CameraMode
    {
        Exploration,
        Combat,
        Topdown1,
        Topdown2,
        Topdown3
    }

    void Start()
    {
        
    }

    void Update()
    {
        /// Rotate orientation
        Vector3 lookDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        lookDirection.forward = lookDir.normalized;

        
        /// Rotate player object
        if (currentMode == CameraMode.Exploration || currentMode == CameraMode.Topdown1 || currentMode == CameraMode.Topdown2 || currentMode == CameraMode.Topdown3)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 inputDir = lookDirection.forward * verticalInput + lookDirection.right * horizontalInput;

            if (inputDir != Vector3.zero)
            {
                playerModel.forward = Vector3.Slerp(playerModel.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
        }

        else if (currentMode == CameraMode.Combat)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            lookDirection.forward = dirToCombatLookAt.normalized;

            player.forward = dirToCombatLookAt.normalized;  
        }
    }
}
