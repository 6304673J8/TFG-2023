using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = CheckPoint.GetActiveCheckPointPosition();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {

        }
    }
}

    
