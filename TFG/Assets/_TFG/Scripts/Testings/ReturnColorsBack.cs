using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnColorsBack : MonoBehaviour
{
    [ColorUsage(true, true)]
    Renderer[] characterMaterials;
    public Color[] hornColors;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ChangeMaterialSettings(0);
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
}
