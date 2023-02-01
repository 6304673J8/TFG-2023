using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDisparo : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetOrientation = _target.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.red);


        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, Time.deltaTime);
    }
} 
