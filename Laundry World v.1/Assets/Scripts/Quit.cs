// Script skrivet av Maria Görman

using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour
{

	public void quitGame()
	{
		Application.Quit ();
		Debug.Log ("bye!");	
	}
	}