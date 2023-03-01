using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed = 18f;
    [SerializeField]
    private float _timelife = 100f;

    void Start()
    {
        Destroy(gameObject, _timelife);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);

        }
    }
}
