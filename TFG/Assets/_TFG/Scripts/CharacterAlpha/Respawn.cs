using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;
    private Transform Spawn;

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = Spawn.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Inicio":
                Spawn.position = new Vector3(-9.93999958f, 2.852f, 0.143f);
            break;
        }
    }
}

    
