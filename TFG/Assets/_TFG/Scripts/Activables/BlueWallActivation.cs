using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueWallActivation : MonoBehaviour
{
    public Material dissolveMat;
    int LayerIgnoreRaycast;
    private bool activated;

    // Start is called before the first frame update
    void Start()
    {
        LayerIgnoreRaycast = LayerMask.NameToLayer("Entity_Blue");
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dissolveMat.GetFloat("_Transicion") >= 1 && activated == false)
            activated = true;
        if (activated)
        {
            gameObject.layer = LayerIgnoreRaycast;
        }
    }
}
