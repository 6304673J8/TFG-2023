using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    Renderer _playerRenderer;

    private void OnTriggerEnter(Collider other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();
        IPowerUp powerUp = other.GetComponent<IPowerUp>();
        AnimationAndMovementController player = other.GetComponent<AnimationAndMovementController>();

        //If The Collided Object Takes Part In The Collectible Component Setup, Do
        if (collectible != null)
        {
            collectible.Collect();
            //Add A Return Material Or Material Setter For Player Change
        }

        if (powerUp != null)
        {
            powerUp.UpdateColor(_playerRenderer);
        }

        if (player != null)
        {
            player.HandleColorSwap(0);
        }
        //player.HandleColorSwap(colorToSwap);
    }
}
