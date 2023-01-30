using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

//This Suscriber Works With Color Pickup Events In Order To Change The Players Color
public class ColorPickedSuscriber : MonoBehaviour
{
    [ColorUsage(true, true)]
    Renderer[] characterMaterials;
    public Color[] hornColors;

    // Start is called before the first frame update
    void Start()
    {
        characterMaterials = GetComponentsInChildren<Renderer>();
        ColorPickupEvents colorPickedEvents = GetComponent<ColorPickupEvents>();
        colorPickedEvents.onColorBluePicked += ColorPickedEvent_OnColorPickedBlue;
        colorPickedEvents.onColorRedPicked += ColorPickedEvent_OnColorPickedRed;
        colorPickedEvents.onColorGreenPicked += ColorPickedEvent_OnColorPickedGreen;
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

    //Blue
    private void ColorPickedEvent_OnColorPickedBlue(object sender, EventArgs e)
    {
        Debug.Log("Color Picked Blue!");
        ChangeMaterialSettings(0);
        //Example If The Script Is In Another GameObject
        //ColorPickupEvents colorPickupEvents = (ColorPickupEvents)sender;
        ColorPickupEvents colorPickedEvents = GetComponent<ColorPickupEvents>();
        colorPickedEvents.onColorBluePicked -= ColorPickedEvent_OnColorPickedBlue;
    }

    //Red
    private void ColorPickedEvent_OnColorPickedRed(object sender, EventArgs e)
    {
        Debug.Log("Color Picked Red!");
        ChangeMaterialSettings(1);
        //Example If The Script Is In Another GameObject
        //ColorPickupEvents colorPickupEvents = (ColorPickupEvents)sender;
        ColorPickupEvents colorPickedEvents = GetComponent<ColorPickupEvents>();
        colorPickedEvents.onColorRedPicked += ColorPickedEvent_OnColorPickedRed;
    }

    //Green
    private void ColorPickedEvent_OnColorPickedGreen(object sender, EventArgs e)
    {
        Debug.Log("Color Picked Green!");
        ChangeMaterialSettings(2);
        //Example If The Script Is In Another GameObject
        //ColorPickupEvents colorPickupEvents = (ColorPickupEvents)sender;
        ColorPickupEvents colorPickedEvents = GetComponent<ColorPickupEvents>();
        colorPickedEvents.onColorGreenPicked += ColorPickedEvent_OnColorPickedGreen;
    }
}