//using UnityEngine;



//public class LoopingBackground : MonoBehaviour
//{
//    public float speed = 5f; // Speed at which the buildings move
//    public float loopDistance = 200f; // Distance at which the buildings loop
//    private Vector3 startPosition; // Starting position of the buildings

//    void Start()
//    {
//        startPosition = transform.position;
//    }

//    void Update()
//    {
//        transform.Translate(-Vector3.right * Time.deltaTime * speed); // Move the buildings to the left


//        if (Vector3.Distance(transform.position, startPosition) > loopDistance)
//        {
//            transform.position = startPosition; // Teleport the buildings back to the start
//        }
//    }
//}
using UnityEngine;
using System.Collections;

public class LoopingBackground : MonoBehaviour
{
    public float speed = 5f; // Speed at which the buildings move
    public float loopDistance = 200f; // Distance at which the buildings loop
    private Vector3 startPosition; // Starting position of the buildings
    private float movementTime; // Time it takes for the buildings to loop
    private float currentTime = 0; // Current time during the movement
    private bool isMoving = true; // Flag to indicate if the buildings are moving

    void Start()
    {
        startPosition = transform.position;
        movementTime = loopDistance / speed;
        StartCoroutine(LoopingBackgroundCoroutine());
    }

    void Update()
    {
        if (isMoving)
        {
            currentTime += Time.deltaTime;
            float distanceCovered = Mathf.Lerp(0, loopDistance, currentTime / movementTime);
            transform.position = startPosition - Vector3.right * distanceCovered;

            if (currentTime >= movementTime)
            {
                currentTime = 0;
                isMoving = false;
            }
        }
    }

    IEnumerator LoopingBackgroundCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(movementTime);
            isMoving = true;
        }
    }
}