using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkPoints;

    [SerializeField] Vector3 vectorPoint;

    [SerializeField] float dead = 0.5f;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("VectorPoint: " + vectorPoint);
        if (Input.GetKeyDown(KeyCode.O))
        {
            isDead = true;
            //Debug.Log("Key Pressed");
        }
        if (isDead == true)
        {
            Debug.Log("TP: " + vectorPoint);
                player.transform.position = vectorPoint;
                //player.transform.position = checkPoints.transform.position;
                isDead = false;
            //EditorApplication.isPaused = true;

        }
       
    }

   /* IEnumerator waitForDeath()
    {
        yield return new WaitForSeconds(dead);
        Debug.Log("Wait");
       
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            vectorPoint = other.gameObject.transform.position;
        }
        
        //Destroy(other.gameObject);
    }
}
