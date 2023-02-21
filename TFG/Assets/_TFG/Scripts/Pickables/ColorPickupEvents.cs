using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ColorPickupEvents : MonoBehaviour
{
    public event EventHandler onColorTouched;
    public event EventHandler onColorBluePicked;
    public event EventHandler onColorRedPicked;
    public event EventHandler onColorGreenPicked;

    public GameObject ColorTest;
    public GameObject BodyLayer;

    private EmpujarCaja _empujarCaja;

    private void Start()
    {
        _empujarCaja = GetComponent<EmpujarCaja>();
    }

    //Update Testings
    private void Update()
    {
        /* Testings
         * if (Input.GetKeyDown(KeyCode.Space))
        {
            onColorPicked?.Invoke(this, EventArgs.Empty);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ColorTest.gameObject.SetActive(true);
        }*/
    }
    
    //Find A Proper Way Of Doing This Once The Project Is Accepted!!!!!
    /*Original
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
     */

    private void LayerChanger(Collider other, string color)
    {
        Debug.Log(BodyLayer.layer);
        Debug.Log(other.gameObject.layer);
        Debug.Log("End Of Debug " + color);
        BodyLayer.layer = other.gameObject.layer;
        Debug.Log("Collided With Pickeable");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick_Color_Blue"))
        {
            LayerChanger(other, "BLUE");
            _empujarCaja.enabled = false;
            onColorBluePicked?.Invoke(this, EventArgs.Empty);
            //other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Pick_Color_Red"))
        {
            LayerChanger(other, "RED");
            _empujarCaja.enabled = false;
            onColorRedPicked?.Invoke(this, EventArgs.Empty);
            //other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Pick_Color_Green"))
        {
            LayerChanger(other, "GREEN");
            _empujarCaja.enabled = true;
            onColorGreenPicked?.Invoke(this, EventArgs.Empty);
            //other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Pick_Color_White"))
        {
            LayerChanger(other, "WHITE");
            _empujarCaja.enabled = false;
            onColorGreenPicked?.Invoke(this, EventArgs.Empty);
            //other.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Collided With Random");
        }
    }
}