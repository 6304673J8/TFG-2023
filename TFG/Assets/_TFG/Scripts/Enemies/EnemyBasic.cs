using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    public GameObject collision;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Working - Killing");
        switch (other.tag)
        {
            case "Player":
                if (other.gameObject.layer == this.gameObject.layer)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }
}
