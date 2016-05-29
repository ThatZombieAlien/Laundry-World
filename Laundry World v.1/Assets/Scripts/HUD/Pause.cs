//script skrivet av Maria Görman
using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GameObject pauseButton, pausePanel, helpPanel;

	public void Start()
	{
		OnUnpause ();
	}
	public void Onpause() //pausar spelet
	{
		pausePanel.SetActive (true);
		pauseButton.SetActive (false);
		Time.timeScale = 0;

	}

	public void OnUnpause() //resumar spelet
    {
		pausePanel.SetActive (false);
		pauseButton.SetActive (true);
		Time.timeScale = 1;
	}
}


