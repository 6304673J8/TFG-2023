using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpadScript : MonoBehaviour
{

    public float jumpSpeed;
    GameObject player;

    public Material dissolveMat;
    public float Color;
   
    // Start is called before the first frame update
    void Start()
    {
        Color = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dissolveMat.SetFloat("_Transicion", Color);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            if(Color == 1)
            {
                Jump();
            }
            
        }
       
      
    }

    private void Jump()
    {   
            Rigidbody rig = player.GetComponent<Rigidbody>();
            rig.AddForce(player.transform.up * jumpSpeed, ForceMode.Impulse);
        
    }
}