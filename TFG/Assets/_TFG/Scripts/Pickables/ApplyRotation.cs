using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRotation : MonoBehaviour
{
    [SerializeField] private float _rotateX = 0f, _rotateY = 15f, _rotateZ = 0f;

    private void LateUpdate()
    {
        Vector3 newRotation = new Vector3(_rotateX, _rotateY, _rotateZ);
        transform.Rotate(newRotation * Time.deltaTime);
    }
}
