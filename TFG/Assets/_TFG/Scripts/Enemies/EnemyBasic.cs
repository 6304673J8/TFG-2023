using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    public GameObject Objeto1; 
    private bool Muerto;
    
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
        Objeto1.GetComponent<ReturnColorToObject>().StartChanging();
    }
}
