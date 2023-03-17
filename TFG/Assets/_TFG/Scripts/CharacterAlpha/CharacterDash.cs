using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash : MonoBehaviour
{
    AnimationAndMovementController moveScript;

    public float dashSpeed;
    public float dashTime;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<AnimationAndMovementController>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
