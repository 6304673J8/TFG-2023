using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Being An ICollectible Let The Collector Script Call The Base Behaviour Of This Object
public class RedPowerUp : PowerUp, IPowerUp
{
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.CompareTag("Player") == true)
        {
            _playerPowerUp.PowerUpActivation(0);
            _playerColorSwap.HandleColorSwap(0);
        }
    }
    
    public void PlaySFX()
    {
        throw new NotImplementedException();
    }

    public void PlayVFX()
    {
        throw new NotImplementedException();
    }
}