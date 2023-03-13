using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerManager : MonoBehaviour
{
    private bool inDanger;
    public List<GameObject> enemyList;
    
    // Start is called before the first frame update
    void Start()
    {
        inDanger = false;
        enemyList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.Count > 0)
        {
            inDanger = true;
        }
        else
        {
            inDanger = false;
        }
    }

    public bool GetIsInDanger()
    {
        return inDanger;
    }
}
