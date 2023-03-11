using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
 
public class VideoManager : MonoBehaviour
{
	[SerializeField]
	private VideoPlayer video;
	[SerializeField]
	private string _sceneName;

    // Play on awake defaults to true. Set it to false to avoid the url set
    // below to auto-start playback since we're in Start().
	void Start()
    {
        video.Play();
        video.loopPointReached += CheckOver;
    }
 
     void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(_sceneName);
    }

	public void Skip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
