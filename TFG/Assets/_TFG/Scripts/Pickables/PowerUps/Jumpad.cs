using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpad : MonoBehaviour
{

    public float jumpSpeed;
    public Vector3 impulse;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.GetComponent<LayerMask>();
        CharacterController controller;
        AnimationAndMovementControllerTest player = collision.GetComponent<AnimationAndMovementControllerTest>();
        if (collision.gameObject.layer == 10)
        {
            Debug.Log("colisiona");

            player.ApplyImpulse();
            /*controller = collision.GetComponent<CharacterController>();
            Debug.Log("colisiona");
            moveDirection =  impulse * jumpSpeed;
            controller.Move(moveDirection);*/
        }
    }

    private void Jump(Vector3 direction)
    {
        //CharacterController rig = player.GetComponent<CharacterController>();
        //rig.gameObject = moveDirection * impulse * jumpSpeed;
    }
}
