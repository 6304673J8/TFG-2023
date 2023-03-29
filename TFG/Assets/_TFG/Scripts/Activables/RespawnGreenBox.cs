using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnGreenBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ReturnToOriginalPosition>() == true)
            other.gameObject.GetComponent<ReturnToOriginalPosition>().ReturnOriginalPosition();
    }
}
