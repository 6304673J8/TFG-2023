using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpad : MonoBehaviour
{

    public float jumpSpeed;
    public Vector3 impulse;
    private Vector3 moveDirection;

    public Material dissolveMat;
    public float Color;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        dissolveMat.SetFloat("_Transicion", Color);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //PowerUpHandler player = collision.GetComponent<PowerUpHandler>();
        AnimationAndMovementController player = collision.GetComponent<AnimationAndMovementController>();
        if (collision.gameObject.layer == this.gameObject.layer)
        {
            Debug.Log("colisiona");
            if (Color == 1)
            {
                player.ApplyImpulse(impulse);
            }
 
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
