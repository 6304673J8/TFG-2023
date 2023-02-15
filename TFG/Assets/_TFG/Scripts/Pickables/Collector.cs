using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();
        AnimationAndMovementController player = other.GetComponent<AnimationAndMovementController>();

        //If The Collided Object Takes Part In The Collectible Component Setup, Do
        if (collectible != null)
        {
            collectible.Collect();
            collectible.UpdateColor();
            //Add A Return Material Or Material Setter For Player Change
        }

        if (player != null)
        {
            player.HandleColorSwap(0);
        }
        //player.HandleColorSwap(colorToSwap);
    }
}
