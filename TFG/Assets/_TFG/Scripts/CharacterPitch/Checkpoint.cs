using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<UltimoCheckpoint>().lastCheckpoint = GetComponent<Transform>().position;
            Destroy(gameObject);
        }
    }

}
