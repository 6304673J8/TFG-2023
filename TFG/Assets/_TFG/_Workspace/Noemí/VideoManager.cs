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

	void Awake()
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
