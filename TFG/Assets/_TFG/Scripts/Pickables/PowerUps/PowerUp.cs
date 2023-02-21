using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    //[SerializeField] private string _powerUpName;

    protected PowerUpHandler _playerPowerUp;
    protected ColorSwapHandler _playerColorSwap;
    void Start()
    {
        _playerPowerUp = FindObjectOfType<PowerUpHandler>();
        _playerColorSwap = FindObjectOfType<ColorSwapHandler>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Play Animation Of Power Up Picked");
        }
    }
}
