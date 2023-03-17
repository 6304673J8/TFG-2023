using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    [SerializeField]
    private LayerMask interactablesLayerMask;

    public GameObject Objeto1;
   
    private bool Muerto;

    // Start is called before the first frame update
    void Start()
    {
        Muerto = false;
 
    }

    // Update is called once per frame
    void Update()
    {
        

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
                    Objeto1.GetComponent<MeshRenderer>().material.SetFloat("_Transicion", 1);
                    Objeto1.GetComponent<Rigidbody>().isKinematic = false;

                    Muerto = true;
                    //Destroy(gameObject);
                }
                break;
        }
    }
}
