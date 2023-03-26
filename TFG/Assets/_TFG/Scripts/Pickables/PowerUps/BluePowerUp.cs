using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Being An ICollectible Let The Collector Script Call The Base Behaviour Of This Object
public class BluePowerUp : PowerUp, IPowerUp
{
    protected override void OnTriggerEnter(Collider other)
    {
        Debug.Log("Picked Object");
        base.OnTriggerEnter(other);
        
        _playerPowerUp.PowerUpActivation(2);
        _playerColorSwap.HandleColorSwap(2);
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
