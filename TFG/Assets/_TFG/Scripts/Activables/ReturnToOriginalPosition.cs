using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToOriginalPosition : MonoBehaviour
{
    [Tooltip("The Transform that the object will return to")]
    Vector3 returnToPosition;

    void Awake()
    {
        returnToPosition = this.transform.position;
    }

    public void ReturnOriginalPosition()
    {
        transform.position = returnToPosition;
    }
}
