// Script skrivet av Maria Görman

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName); //laddar scene med scenenamnet man skriver in
	}
}
