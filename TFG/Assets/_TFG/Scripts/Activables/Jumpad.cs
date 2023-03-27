using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpad : MonoBehaviour
{
    public float jumpSpeed;
    public Vector3 impulse;
    private Vector3 moveDirection;
    private Animator _animator;
    public bool canJump;
    private Renderer _rend;
    
    private void Start()
    {
        canJump = false;
        _rend = GetComponent<Renderer>();
        _animator = GetComponent<Animator>();
    }

    private void SetAnimationOn()
    {
        _animator.SetBool("isBouncing", true);
    }

    private void SetAnimationOff()
    {
        _animator.SetBool("isBouncing", false);
    }

    public void SetCanJump()
    {
        if (canJump)
            canJump = false;
        else if (!canJump)
            canJump = true;
    }
    
    private void OnTriggerStay(Collider collision)
    {
        AnimationAndMovementController player = collision.GetComponent<AnimationAndMovementController>();
        if (collision.gameObject.layer == this.gameObject.layer)
        {
            Debug.Log("Entra En Trigger");
            if (_rend.material.GetFloat("_Transicion") > 0)
            {
                Debug.Log("Entra En Material Analizator");
                SetAnimationOn();
                if (canJump == true)
                {
                    player.ApplyImpulse(impulse);
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        AnimationAndMovementController player = collision.GetComponent<AnimationAndMovementController>();
        if (collision.gameObject.layer == this.gameObject.layer)
        {
            SetAnimationOff();
        }
    }
}
