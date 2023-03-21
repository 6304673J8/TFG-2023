using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAltura : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spwanValue;


    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -spwanValue)
        {
            RespawnPoint();
        }
    }

    void RespawnPoint()
    {
        transform.position = spawnPoint.position;
    }
}