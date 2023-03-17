using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpadScript : MonoBehaviour
{

    public float jumpSpeed;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody rig = player.GetComponent<Rigidbody>();
        rig.AddForce(player.transform.up * jumpSpeed, ForceMode.Impulse);
    }
}