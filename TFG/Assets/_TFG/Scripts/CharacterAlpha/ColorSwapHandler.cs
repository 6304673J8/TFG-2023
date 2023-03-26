using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ColorSwapHandler : MonoBehaviour
{
    public enum ColorPicked
    {
        Color_Green,
        Color_Blue,
        Color_Red,
        Color_White
    }
    public Material[] _materials;
    //Visuals
    [SerializeField]
    private Renderer _playerRenderer;
    //ToDelete
    [SerializeField]
    private GameObject _testRenderer;

    public ColorPicked _colorPicked;

    #region ColorSwap

    public void HandleColorSwap(int colorToSwap)
    {

        switch (colorToSwap)
        {
            default:
                Debug.Log("Ente Handle Color: white");
                _colorPicked = ColorPicked.Color_White;
                _testRenderer.GetComponent<Renderer>().material.color = Color.white;
                _playerRenderer.material = _materials[3];
                return;
            case 0:
                Debug.Log("Swapping To Red");
                _colorPicked = ColorPicked.Color_Red;
                _testRenderer.GetComponent<Renderer>().material.color = Color.red;
                _playerRenderer.material = _materials[0];
                return;
            case 1:
                Debug.Log("Swapping To Green");
                _colorPicked = ColorPicked.Color_Green;
                _testRenderer.GetComponent<Renderer>().material.color = Color.green;
                _playerRenderer.material = _materials[1];
                return;
            case 2:
                Debug.Log("Swapping To Blue");
                _colorPicked = ColorPicked.Color_Blue;
                _testRenderer.GetComponent<Renderer>().material.color = Color.blue;
                _playerRenderer.material = _materials[2];
                return;
            case 3:
                Debug.Log("Swapping To White");
                _colorPicked = ColorPicked.Color_White;
                _testRenderer.GetComponent<Renderer>().material.color = Color.white;
                _playerRenderer.material = _materials[3];
                return;
        }
    }

    #endregion
}
