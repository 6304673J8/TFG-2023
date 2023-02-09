using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Being An ICollectible Let The Collector Script Call The Base Behaviour Of This Object
public class GreenPowerUp : MonoBehaviour, ICollectible
{
    public static event Action OnRedPowerUpCollected;

    public void Collect()
    {
        Debug.Log("You Collected The Green Power Up");
        Destroy(gameObject);
        OnRedPowerUpCollected?.Invoke();
    }
}
