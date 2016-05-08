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
	public void OnPause() //pausar
{
		
			pausepanel.SetActive (true); //visar pausemenyn
			pauseButton.SetActive (false); //tar bort pauseknappen
			Time.timeScale = 0; //pausar spelet
	}

	public void UnPause() //opausar
	{
		
		pausepanel.SetActive (false);
		pauseButton.SetActive (true);
		Time.timeScale = 1;

	}

	

}
