using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalColorAndTextureChanger : MonoBehaviour
{
    [ColorUsage(true, true)]
    Renderer[] characterMaterials;
    public Color[] _scenarioColors;
    public Material[] _material;
    public Texture[] _albedoTexture;

    private void Start()
    {
        characterMaterials = GetComponentsInChildren<Renderer>();
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
        for (int i = 0; i < characterMaterials.Length; i++)
        {
            if (characterMaterials[i].transform.CompareTag("Set_Color"))
            {
                characterMaterials[i].material.SetColor("_BaseColor", _scenarioColors[index]);
                characterMaterials[i].material.SetColor("_EmissionColor", _scenarioColors[index]);
            }
            else if (characterMaterials[i].transform.CompareTag("Steal_Color"))
                characterMaterials[i].material = _material[index];
            else if (characterMaterials[i].transform.CompareTag("Pick_Color"))
                characterMaterials[i].material.mainTexture = _albedoTexture[index];
                //characterMaterials[i].material.SetTexture("_MainTex", _albedoTexture[index]);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
}
