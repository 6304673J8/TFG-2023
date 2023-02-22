using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimoCheckpoint : MonoBehaviour
{
    public Vector3 lastCheckpoint;
    public int vida;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            vida -= 10;
        }

        if(vida == 0)
        {
            GetComponent<CharacterController>().enabled = false;
            transform.position = lastCheckpoint;
            GetComponent<CharacterController>().enabled = false;
        }
    }




}
