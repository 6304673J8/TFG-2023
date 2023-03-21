using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Skip()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame

}
