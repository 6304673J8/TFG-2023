using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Being An ICollectible Let The Collector Script Call The Base Behaviour Of This Object
public class BluePowerUp : MonoBehaviour, IPowerUp
{
    public static event Action<Renderer> OnGreenPowerUpCollected;

    public Renderer _rendATest;

    public Renderer renderer
    {
        get { return gameObject.GetComponent<Renderer>(); }
    }

    public void UpdateColor(Renderer renderer)
    {
        Debug.Log("You Collected The Blue Power Up");
        //renderer = _rendATest;
        OnGreenPowerUpCollected?.Invoke(_rendATest);
        renderer.material.SetColor("BaseColor", Color.blue);
    }

    private void OnTriggerEnter(Collider other)
    {
        ColorSwapHandler player = other.GetComponent<ColorSwapHandler>();

        if (player != null)
        {
            _rendATest = player._renderer;
            Debug.Log("You Triggered The Blue PowerUp");
            Debug.Log("Picked " + _rendATest);
            Debug.Log("Picked " + renderer);
            //UpdateColor(player._renderer);
            UpdateColor(player._renderer);
            //player.HandleColorSwap(2);
        }
    }
}
