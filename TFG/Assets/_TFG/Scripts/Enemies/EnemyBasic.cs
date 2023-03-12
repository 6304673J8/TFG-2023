using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    [SerializeField]
    private LayerMask interactablesLayerMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (other.gameObject.layer == this.gameObject.layer)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }
}
