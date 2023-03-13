using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyType : MonoBehaviour
{
    public enum ColorPicked
    {
        Color_Green,
        Color_Blue,
        Color_Red,
        Color_Black
    }
    public Material[] _materials;
    //Visuals
    [SerializeField]
    private Renderer _entityRenderer;
    //ToDelete
    [SerializeField]
    private GameObject _testRenderer;

    public ColorPicked _colorPicked;

    #region ColorSwap

    private void Awake()
    {
        HandleEnemyColor((int)_colorPicked);
    }

    public void HandleEnemyColor(int colorToSwap)
    {
        switch (colorToSwap)
        {
            default:
                _colorPicked = ColorPicked.Color_Black;
                _testRenderer.GetComponent<Renderer>().material.color = Color.white;
                _entityRenderer.material = _materials[3];
                return;
            case 0:
                Debug.Log("Swapping To Red");
                _colorPicked = ColorPicked.Color_Red;
                _testRenderer.GetComponent<Renderer>().material.color = Color.red;
                _entityRenderer.material = _materials[0];
                return;
            case 1:
                Debug.Log("Swapping To Green");
                _colorPicked = ColorPicked.Color_Green;
                _testRenderer.GetComponent<Renderer>().material.color = Color.green;
                _entityRenderer.material = _materials[1];
                return;
            case 2:
                Debug.Log("Swapping To Blue");
                _colorPicked = ColorPicked.Color_Blue;
                _testRenderer.GetComponent<Renderer>().material.color = Color.blue;
                _entityRenderer.material = _materials[2];
                return;
            case 3:
                Debug.Log("Swapping To White");
                _colorPicked = ColorPicked.Color_Black;
                _testRenderer.GetComponent<Renderer>().material.color = Color.black;
                _entityRenderer.material = _materials[3];
                return;
        }
    }

    #endregion
}