using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public float lerpSpeed;
    PlayerController player;
    Rigidbody playerRb;

    Rigidbody rb;
    Transform grabPoint;
    Collider objectCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        objectCollider = GetComponent<Collider>();
        player = FindObjectOfType<PlayerController>();
    }

    public void Grab(Transform grabPoint)
    {
        this.grabPoint = grabPoint;
        rb.isKinematic = true;
        transform.parent = grabPoint.transform;

        //rb.useGravity = false;
        //objectCollider.enabled = false;
    }

    public void Drop()
    {
        this.grabPoint = null;
        rb.isKinematic = false;
        transform.parent = null;
        rb.AddForce(player.playerRb.velocity * 5f, ForceMode.VelocityChange);
        //rb.useGravity = true;
        //objectCollider.enabled = true;
    }

    public void Throw()
    {
        this.grabPoint = null;
        rb.isKinematic = false;
        transform.parent = null;
        rb.AddForce(player.playerRb.velocity * 5f, ForceMode.VelocityChange);
    }

    private void FixedUpdate()
    {
        if (grabPoint != null)
        {
            Vector3 grabPos = Vector3.Lerp(transform.localPosition, Vector3.zero, Time.deltaTime * lerpSpeed);
            rb.transform.localPosition = grabPos;
        }
    }
}
