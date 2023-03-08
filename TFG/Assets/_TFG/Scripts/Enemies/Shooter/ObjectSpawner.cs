using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float despawn = 500000;
    public GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnOnject()
    {
        GameObject temp = Instantiate(objeto, transform.position, transform.rotation);
        Destroy(temp, despawn);
    }
}
