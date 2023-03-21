    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptBotonFinalNivel1_Azul : MonoBehaviour
{
    public GameObject Boton;
    public ParticleSystem confeti;
    public Material botonActivado;
    public float delay;
    [SerializeField] string _nextScene;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
            {
            Boton.GetComponent<MeshRenderer>().material = botonActivado;
            Instantiate(confeti, transform.position, Quaternion.identity);
            StartCoroutine(LoadNextScene(_nextScene));
        }
    }

    private IEnumerator LoadNextScene(string levelName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(levelName);
    }
}
