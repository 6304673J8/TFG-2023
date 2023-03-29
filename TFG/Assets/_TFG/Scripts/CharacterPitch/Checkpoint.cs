
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private GameObject flagCheckpoint;
    public bool Activated = false;

    #region Private Variables

    //private Animator thisAnimator;

    #endregion

    #region Static Variables

    public static List<GameObject> CheckPointsList;

    #endregion

    #region Static Functions

    public static Vector3 GetActiveCheckPointPosition()
    {

        Vector3 result = new Vector3(0, 0, 0);

        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {

                if (cp.GetComponent<Checkpoint>().Activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }

        return result;
    }

    #endregion

    #region Private Functions

    private void ActivateCheckPoint()
    {

        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<Checkpoint>().Activated = false;
            // cp.GetComponent<Animator>().SetBool("Active", false);
        }

        Activated = true;
        //thisAnimator.SetBool("Active", true);
    }

    #endregion

    void Start()
    {
        //thisAnimator = GetComponent<Animator>();

        CheckPointsList = GameObject.FindGameObjectsWithTag("Checkpoint").ToList();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            flagCheckpoint.GetComponent<ReturnColorToObject>().StartChanging();
            ActivateCheckPoint();
        }
    }
}