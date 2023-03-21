using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private bool TocandoCharco;
    void Update()
    {
        if (Input.GetKey(KeyCode.R) || TocandoCharco == true)
        {
            transform.position = Checkpoint.GetActiveCheckPointPosition();
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Muerte")
        {
            TocandoCharco = true;
        }
        else
        {
            TocandoCharco = false;
        }
    }

}