using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTrigger : MonoBehaviour
{
    public float upwardForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
            rb.useGravity = false;
        }
    }
}