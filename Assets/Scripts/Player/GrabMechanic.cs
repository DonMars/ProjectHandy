using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMechanic : MonoBehaviour
{
    public Transform grabPoint;
    PlayerController player;
    Grabbable grabbable;

    float holdStartTime;

    void Awake()
    {
        player = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (player.canGrab && Input.GetKeyDown(player.grabKey))
        {
            if (grabbable == null) // If not carrying, try to grab
            {
                if (other.TryGetComponent(out grabbable))
                {
                    grabbable.Grab(grabPoint);
                    player.isGrabbing = true;
                    holdStartTime = Time.time;
                    
                }
            }
            else // If carrying, drop
            {
                grabbable.Drop();
                grabbable = null;
                player.isGrabbing = false;
            }
        }

        if (player.canGrab && player.isGrabbing && Input.GetKeyUp(player.grabKey))
        {
            float holdDownTime = Time.time - holdStartTime;
            grabbable.Throw();
            grabbable = null;
            player.isGrabbing = false;
            
        }
    }
}
