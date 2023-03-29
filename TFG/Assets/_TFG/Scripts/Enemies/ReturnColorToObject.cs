using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnColorToObject : MonoBehaviour
{
    #region ShaderValues
    public Material dissolveMat;
    private float colorValue;
    private float change;
    private float delay;
    #endregion
    Rigidbody m_Rigidbody;
    public bool isCaja;

    private void Awake()
    {
        colorValue = 0f;
        change = 0.15f;
        delay = 0.1f;
    }
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        dissolveMat.SetFloat("_Transicion", colorValue);
    }

    public void StartChanging()
    {
        StartCoroutine(Changeshader());
        if (isCaja == true)
            m_Rigidbody.isKinematic = false;
    }

    IEnumerator Changeshader()
    {
        while (colorValue < 1f)
        {
            yield return new WaitForSeconds(delay);
            colorValue += change;
            dissolveMat.SetFloat("_Transicion", colorValue);
        }
    }
}
