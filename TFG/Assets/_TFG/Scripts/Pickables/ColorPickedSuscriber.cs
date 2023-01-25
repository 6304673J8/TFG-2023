using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

//This Suscriber Works With Color Pickup In Order To Change The Players Color
public class ColorPickedSuscriber : MonoBehaviour
{
    [ColorUsage(true, true)]
    Renderer[] characterMaterials;
    public Color[] hornColors;

    // Start is called before the first frame update
    void Start()
    {
        characterMaterials = GetComponentsInChildren<Renderer>();
        ColorPickupEvents colorPickedEvent = GetComponent<ColorPickupEvents>();
        colorPickedEvent.onColorPicked += ColorPickedEvent_OnColorPicked;
    }

    void ChangeMaterialSettings(int index)
    {
        for (int i = 0; i < characterMaterials.Length; i++)
        {
            if (characterMaterials[i].transform.CompareTag("Horn_Color"))
                characterMaterials[i].material.SetColor("_EmissionColor", hornColors[index]);
            /*else
                characterMaterials[i].material.SetTexture("_MainTex", albedoList[index]);*/
        }
    }

    private void ColorPickedEvent_OnColorPicked(object sender, EventArgs e)
    {
        Debug.Log("Color Picked!");
        ChangeMaterialSettings(1);
        //Example If The Script Is In Another GameObject
        //ColorPickupEvents colorPickupEvents = (ColorPickupEvents)sender;
        ColorPickupEvents colorPickupEvents = GetComponent<ColorPickupEvents>();
        colorPickupEvents.onColorPicked -= ColorPickedEvent_OnColorPicked;
    }
}
