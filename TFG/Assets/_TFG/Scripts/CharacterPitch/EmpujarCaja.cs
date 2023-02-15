using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpujarCaja : MonoBehaviour
{
    public float pushPower = 2.0f;

    bool estaActivo;
    // Start is called before the first frame update
    void Start()
    {
        estaActivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            ToggleBoxActive();
        }
    }

    private void ToggleBoxActive()
    {
        if (estaActivo == true)
            estaActivo = false;
        else if (estaActivo == false)
            estaActivo = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (estaActivo)
        {
            if (body == null || body.isKinematic)
            {
                return;
            }
            if (hit.moveDirection.y < -0.3)
            {
                return;
            }
            Debug.Log("Empujando");
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            body.velocity = pushDir * pushPower;
        }
        else if (!estaActivo)
        {
            if (body == null || body.isKinematic)
            {
                return;
            }
            if (hit.moveDirection.y < -0.3)
            {
                return;
            }
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            body.velocity = pushDir * 0;
        }

    }
}
