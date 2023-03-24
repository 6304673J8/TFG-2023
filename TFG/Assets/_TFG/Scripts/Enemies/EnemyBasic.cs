using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    public GameObject Objeto1; 
    private bool Muerto;
    private Cinemachine.CinemachineImpulseSource cameraShake;
    public bool activable;

    private void Awake()
    {
        cameraShake = GetComponent<Cinemachine.CinemachineImpulseSource>();
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
                    if(activable == true)
                    {
                        Objeto1.SetActive(false);
                    }
                    Muerto = true;
                    Morir();
                }
                break;
        }
    }

    public void Morir()
    {
        cameraShake.GenerateImpulse();
        if (activable != true)
            Objeto1.GetComponent<ReturnColorToObject>().StartChanging();
    }
}
