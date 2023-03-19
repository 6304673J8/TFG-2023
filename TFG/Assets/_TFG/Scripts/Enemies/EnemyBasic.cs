using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    [SerializeField]
    private LayerMask interactablesLayerMask;

    public GameObject Objeto1;

    JumpadScript Trampolin;
    public bool _Trampolin;
 
   
    private bool Muerto;

    // Start is called before the first frame update
    void Start()
    {
    
 
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Muerto == true)
        {
            Destroy(gameObject);
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
                    Morir();
                }
                break;
        }
    }

    public void Morir()
    {
        Objeto1.GetComponent<MeshRenderer>().material.SetFloat("_Transicion", 1);
        Objeto1.GetComponent<Rigidbody>().isKinematic = false;

        if(_Trampolin == true)
        {
            Trampolin.Color = 1;
        }
        
    }
}
