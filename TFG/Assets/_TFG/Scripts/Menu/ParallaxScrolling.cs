using System.Collections;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public float speed = 5f; // Speed at which the buildings move
    public float loopDistance = 200f; // Distance at which the buildings loop
    
    [SerializeField]
    private Vector3 newPosition;
    private Vector3 startPosition; // Starting position of the buildings
    
    private float movementTime; // Time it takes for the buildings to loop
    private float currentTime = 0; // Current time during the movement
    private bool isMoving = true; // Flag to indicate if the buildings are moving
    [SerializeField]
    private bool _initiateOutOfBoundaries; //Activate For The Group Of Buildings That Will Instantiate Out Of Camera View

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        startPosition = transform.position;
        movementTime = loopDistance / speed;
        //StartCoroutine(LoopingBackgroundCoroutine());
    }

    public void SetNewPosition()
    {
        transform.position = newPosition;
    }
    /*void Update()
    {
        if (isMoving)
        {
            currentTime += Time.deltaTime;
            float distanceCovered = Mathf.Lerp(0, loopDistance, currentTime / movementTime);
            if (!_initiateOutOfBoundaries)
                transform.position = startPosition - Vector3.right * distanceCovered;
            if (currentTime >= movementTime)
            {
                if (_initiateOutOfBoundaries)
                {
                    _initiateOutOfBoundaries = false;
                    transform.position = newPosition - Vector3.right * distanceCovered;
                }
                currentTime = 0;
                isMoving = false;
            }
        }
    }*/

    /*IEnumerator LoopingBackgroundCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(movementTime);
            isMoving = true;
        }
    }*/
}
