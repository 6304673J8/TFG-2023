using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpad : MonoBehaviour
{

    public float jumpSpeed;
    public GameObject player;
    public Vector3 impulse;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent(GameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        moveDirection = collision.GetComponent<Vector3>();
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("colisiona");

            moveDirection =  impulse * jumpSpeed;
        }
    }

    private void Jump(Vector3 direction)
    {
        CharacterController rig = player.GetComponent<CharacterController>();
        //rig.gameObject = moveDirection * impulse * jumpSpeed;
    }
}
