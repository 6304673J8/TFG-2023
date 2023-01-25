using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ColorPickupEvents : MonoBehaviour
{
    public event EventHandler onColorTouched;
    public event EventHandler onColorPicked;

    public GameObject ColorTest;
    public GameObject BodyLayer;

    private void Start()
    {
        onColorTouched += Testing_OnColorTouched;
    }

    private void Testing_OnColorTouched(object sender, EventArgs e)
    {
        Debug.Log("Color Touched: ");
    }

    /*void ChangeMaterialSettings(int index)
    {
        for (int i = 0; i < characterMaterials.Length; i++)
        {
            if (characterMaterials[i].transform.CompareTag("PlayerHorns"))
                characterMaterials[i].material.SetColor("_EmissionColor", hornColors[index]);
            else
                characterMaterials[i].material.SetTexture("_MainTex", albedoList[index]);
        }
    }*/

    //Update Testings
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onColorPicked?.Invoke(this, EventArgs.Empty);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ColorTest.gameObject.SetActive(true);
        }
    }
    //Find A Proper Way Of Doing This Once The Project Is Accepted!!!!!
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick_Color"))
        {
            Debug.Log(BodyLayer.layer);
            Debug.Log(other.gameObject.layer);
            Debug.Log("End Of Debug");
            BodyLayer.layer = other.gameObject.layer;
            Debug.Log("Collided With Pickeable");
            onColorPicked?.Invoke(this, EventArgs.Empty);
            other.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Collided With Random");
        }
    }
}
