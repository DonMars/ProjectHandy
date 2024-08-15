using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class Grabbable : MonoBehaviour
{
    public float lerpSpeed;
    PlayerController player;
    Rigidbody playerRb;
    public ParticleSystem particles;

    Rigidbody rb;
    public Transform grabPoint;
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