using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Being An ICollectible Let The Collector Script Call The Base Behaviour Of This Object
public class RedPowerUp : MonoBehaviour, IPowerUp
{
    public static event Action OnGreenPowerUpCollected;
    public Renderer renderer
    {
        get { return gameObject.GetComponent<Renderer>(); }
    }

    public void UpdateColor(Renderer renderer)
    {
        Debug.Log("You Collected The Green Power Up");
        OnGreenPowerUpCollected?.Invoke();
    }
}
