using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpujarCaja : MonoBehaviour
{
    public float pushPower = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
      
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
       
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(this.enabled){ 
            Rigidbody body = hit.collider.attachedRigidbody;
            
            
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
    }
}
