using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    public GameObject[] activateObject;

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
            activateObject[i].SetActive(true);
        }
        Destroy(gameObject);
    }
}
