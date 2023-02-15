using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalColorAndTextureChanger : MonoBehaviour
{
    [ColorUsage(true, true)]
    Renderer[] _characterMaterials;
    public Color[] _scenarioColors;
    public Color[] _scenarioEmissiveColors;
    public Material[] _material;
    public Texture[] _albedoTexture;

    private void Start()
    {
        _characterMaterials = GetComponentsInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Scenario Changing");
            ChangeMaterialSettings(0);
        }
    }

    // If The Material Is Lit Instead Of "_Color" Use "_BaseColor".
    void ChangeMaterialSettings(int index)
    {
        Debug.Log("Entering Change Material");
        for (int i = 0; i < _characterMaterials.Length; i++)
        {
        Debug.Log("Entrando " + i + " Veces");
            if (_characterMaterials[i].transform.CompareTag("Set_Color"))
                _characterMaterials[i].material.SetColor("_BaseColor", _scenarioColors[index]);
            else if (_characterMaterials[i].transform.CompareTag("Horn_Color"))
                _characterMaterials[i].material.SetColor("_EmissionColor", _scenarioEmissiveColors[index]);
            else if (_characterMaterials[i].transform.CompareTag("Steal_Color"))
                _characterMaterials[i].material = _material[index];
            else if (_characterMaterials[i].transform.CompareTag("Pick_Color"))
                _characterMaterials[i].material.mainTexture = _albedoTexture[index];
                //characterMaterials[i].material.SetTexture("_MainTex", _albedoTexture[index]);
        }
    }
}
