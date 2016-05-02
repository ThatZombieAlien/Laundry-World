using UnityEngine;
using System.Collections;

public class PlayerPurse : MonoBehaviour {

    public static int playerGold = 0;

	void Start () {
	
	}
	

	void Update () {
	
	}

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width - 180, Screen.height * 0.05f, 150, 250));

        GUILayout.Box("Gold:  " + playerGold);

        GUILayout.EndArea();
    }
}
