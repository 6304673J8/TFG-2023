using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();
        //If The Collided Object Takes Part In The Collectible Component Setup, Do
        if (collectible != null)
        {
            collectible.Collect();
            //Add A Return Material Or Material Setter For Player Change
        }
    }
}
