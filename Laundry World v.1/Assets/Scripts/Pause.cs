using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public GameObject pauseButton, pausepanel;
//
//	public void Start()
//
//	{
//		OnUnPause ();
//
//	}
	public void OnPause()
{
		pausepanel.SetActive (true);
		pauseButton.SetActive (false);
		Time.timeScale = 0;
	
	}

	public void UnPause()
	{
		
		pausepanel.SetActive (false);
		pauseButton.SetActive (true);
		Time.timeScale = 1;

	}

	

}
