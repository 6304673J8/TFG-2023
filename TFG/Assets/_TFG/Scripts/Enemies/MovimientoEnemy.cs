using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemy : MonoBehaviour
{
    Animator _animator;
    public Transform[] allwayPoints;
    public float rotationSpeed = .5f, movementSpeed = 0.5f;
    public int currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
        ChangeTarget();
    }

    void Movement()
    {
        _animator.SetBool("isWalking_Enemy", true);
        transform.position = Vector3.MoveTowards(transform.position, allwayPoints[currentTarget].position, movementSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(allwayPoints[currentTarget].position - transform.position), rotationSpeed * Time.deltaTime);
    }

    void ChangeTarget()
    {
        if (transform.position == allwayPoints[currentTarget].position)
        {
            currentTarget++;
            currentTarget = currentTarget % allwayPoints.Length;
        }
    }
}
