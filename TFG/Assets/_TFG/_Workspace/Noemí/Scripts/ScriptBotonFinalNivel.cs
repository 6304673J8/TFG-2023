    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptBotonFinalNivel : MonoBehaviour
{
    public ParticleSystem confeti;
    public Material botonActivado;
    public float delay;
    [SerializeField] string _nextScene;
    [SerializeField] bool _activateByPlayer;
    private Renderer _objectRenderer;

    private void Start()
    {
        _objectRenderer = this.gameObject.GetComponent<Renderer>() ;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisiona");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactable") && _activateByPlayer == false) //check the int value in layer manager(User Defined starts at 8) 
        {
            _objectRenderer.material = botonActivado;
            Instantiate(confeti, transform.position, Quaternion.identity);
            StartCoroutine(LoadNextScene(_nextScene));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true) //check the int value in layer manager(User Defined starts at 8) 
        {
            Debug.Log("Colisiona con objecto activable por jugador");
            _objectRenderer.material = botonActivado;
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
