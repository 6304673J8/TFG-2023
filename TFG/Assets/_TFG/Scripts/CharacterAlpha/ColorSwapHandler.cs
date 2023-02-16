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

    //Visuals
    [SerializeField] private Material[] _material;
    public Renderer _renderer;

    public ColorPicked _colorPicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    #region ColorSwap

    public void HandleColorSwap(int colorToSwap)
    {

        switch (colorToSwap)
        {
            default:
                _colorPicked = ColorPicked.Color_White;
                _renderer.material.color = Color.white;
                return;
            case 0:
                Debug.Log("Swapping To Red");
                _colorPicked = ColorPicked.Color_Red;
                _renderer.material.color = Color.red;
                return;
            case 1:
                Debug.Log("Swapping To Green");
                _colorPicked = ColorPicked.Color_Green;
                _renderer.material.color = Color.green;
                return;
            case 2:
                Debug.Log("Swapping To Blue");
                _colorPicked = ColorPicked.Color_Blue;
                _renderer.material.color = Color.blue;
                return;
            case 3:
                Debug.Log("Swapping To White");
                _colorPicked = ColorPicked.Color_White;
                _renderer.material.color = Color.white;
                return;
        }
    }

    #endregion
}
