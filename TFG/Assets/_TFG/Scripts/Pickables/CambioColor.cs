using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioColor : MonoBehaviour
{
    public Material boubaAzul;
    public GameObject player;


    //  Object.GetComponent<MeshRenderer> ().material = Material1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<MeshRenderer>().material = boubaAzul;
        }

    }

    void Start()
    {

    }
}
