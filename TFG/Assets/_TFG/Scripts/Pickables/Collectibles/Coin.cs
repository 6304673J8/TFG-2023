using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    public static event Action OnCoinCollected;

    public void Collect()
    {
        Debug.Log("You Collected A Key Object");
        Destroy(gameObject);
        OnCoinCollected?.Invoke();
    }
}