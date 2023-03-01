using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnCollide : MonoBehaviour
{
    //Array In Order To Have Multiple Materials
    public Material[] material;
    Renderer rend;
    public GameObject Rocas;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        //Sets The First Material In Array As Default
        rend.sharedMaterial = material[0];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rend.sharedMaterial = material[1];
        }
        else
        {
            rend.sharedMaterial = material[2];
            Rocas.transform.position = new Vector3(-13.072f, -1.8f, 10.871f);
        }
    }
}
