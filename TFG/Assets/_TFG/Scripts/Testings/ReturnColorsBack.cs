using UnityEngine;

public class ReturnColorsBack : MonoBehaviour
{
    [ColorUsage(true, true)]
    Renderer[] characterMaterials;
    public Color[] _scenarioColors;

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
            }
        }
    }
}