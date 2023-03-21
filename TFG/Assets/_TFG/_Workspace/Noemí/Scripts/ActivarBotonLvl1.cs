using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarBotonLvl1 : MonoBehaviour
{

    public GameObject pinturaAzul;

    public GameObject Boton;
    public Material botonActivado;
    // Start is called before the first frame update
    void Start()
    {
        pinturaAzul.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactable")) //check the int value in layer manager(User Defined starts at 8) 
        {
            Boton.GetComponent<MeshRenderer>().material = botonActivado;
            pinturaAzul.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
