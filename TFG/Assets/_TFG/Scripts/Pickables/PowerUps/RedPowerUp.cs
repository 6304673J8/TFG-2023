using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RedPowerUp : MonoBehaviour, ICollectible
{
    public static event Action OnRedPowerUpCollected;

    public void Collect()
    {
        Debug.Log("You Collected The Red Power Up");
        Destroy(gameObject);
        OnRedPowerUpCollected?.Invoke();
    }
}
