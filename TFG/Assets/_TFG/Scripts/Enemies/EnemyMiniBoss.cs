using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMiniBoss : MonoBehaviour
{
    public GameObject Objeto1;
    private bool Muerto;
    private Cinemachine.CinemachineImpulseSource cameraShake;

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
                    Muerto = true;
                    Morir();
                }
                break;
        }
    }

    public void Morir()
    {
        cameraShake.GenerateImpulse();
        Objeto1.GetComponent<ReturnColorsBack>().GiveItBack();
    }
}
