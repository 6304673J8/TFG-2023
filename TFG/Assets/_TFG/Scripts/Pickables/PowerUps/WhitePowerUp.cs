using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Being An ICollectible Let The Collector Script Call The Base Behaviour Of This Object
public class WhitePowerUp : PowerUp, IPowerUp
{
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        
        _playerPowerUp.PowerUpActivation(1);
        _playerColorSwap.HandleColorSwap(3);
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
