using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GameObject pauseButton, pausePanel, helpPanel;
	// Use this for initialization

	public void Start()
	{
		OnUnpause ();
	}
	public void Onpause()
	{
		pausePanel.SetActive (true);
		pauseButton.SetActive (false);
		Time.timeScale = 0;

	}

	public void OnUnpause()
	{
		pausePanel.SetActive (false);
		pauseButton.SetActive (true);
		Time.timeScale = 1;
	}



}


