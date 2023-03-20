using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptBotonFinalNivel : MonoBehaviour
{
    public GameObject Boton;
    public ParticleSystem confeti;
    public Material botonActivado;
    [SerializeField] string _nextScene;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactable")) //check the int value in layer manager(User Defined starts at 8) 
        {
            Boton.GetComponent<MeshRenderer>().material = botonActivado;
            Instantiate(confeti, transform.position, Quaternion.identity);
            StartCoroutine(LoadNextScene(_nextScene));
        }
    }

    private IEnumerator LoadNextScene(string levelName)
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(levelName);
    }
}
