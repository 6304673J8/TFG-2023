using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    public GameObject[] activateObject;
    public bool canActivate;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":

                if (other.gameObject.layer == this.gameObject.layer)
                {
                    Morir();
                }
                break;
        }
    }

    public void Morir()
    {
        for (int i = 0; i < activateObject.Length; i++)
        {
            if (canActivate == false)
                activateObject[i].SetActive(true);
            if (canActivate == true)
            {
                activateObject[0].GetComponent<ReturnColorToObject>().StartChanging();
                activateObject[++i].SetActive(true);
            }
        }
        Destroy(gameObject);
    }
}
