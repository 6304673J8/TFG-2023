using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float jumpForce = 2f;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = (Vector3.up * jumpForce);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
