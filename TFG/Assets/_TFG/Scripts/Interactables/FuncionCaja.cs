using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionCaja : MonoBehaviour
{
    public Material dissolveMat;
    public float Color;
    Rigidbody m_Rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        dissolveMat.SetFloat("_Transicion", Color);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Color == 0)
        {
            m_Rigidbody.isKinematic = true;  
        }
    }
}
