using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    [SerializeField]
    private LayerMask interactablesLayerMask;

    public GameObject CajaVerde;

    
   
    private bool Muerto;

    // Start is called before the first frame update
    void Start()
    {
        Muerto = false;
 
    }

    // Update is called once per frame
    void Update()
    {
        CajaVerde.GetComponent<Renderer>().material.SetFloat("Transicion", 0f);

        if (Muerto == true)
        {
         
        }
 
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                
                if (other.gameObject.layer == this.gameObject.layer)
                {
                    Muerto = true;
                    //Destroy(gameObject);
                }
                break;
        }
    }
}
