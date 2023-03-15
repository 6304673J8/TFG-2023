using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    [SerializeField]
    private LayerMask interactablesLayerMask;

    public GameObject BlackZone;
    public GameObject ColorZone;

    private bool Muerto;

    // Start is called before the first frame update
    void Start()
    {
        Muerto = false;
        BlackZone.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Muerto == true)
        {
            BlackZone.SetActive(false);
            ColorZone.SetActive(true);
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
                    Destroy(gameObject);
                }
                break;
        }
    }
}
