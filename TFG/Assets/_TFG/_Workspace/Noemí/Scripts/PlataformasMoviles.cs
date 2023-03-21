using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasMoviles : MonoBehaviour
{
    public Material dissolveMat;

    public Transform[] points;
    int current;
    public float speed;
    private bool activated;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(dissolveMat.GetFloat("_Transicion") >= 1 && activated == false)
            activated = true;
        if (activated)
        {
            if (transform.position != points[current].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
            }
            else
            {
                current = (current + 1) % points.Length;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}