using UnityEngine;
using System.Collections;

public class PlayerPurse : MonoBehaviour
{
    public static int playerGold = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnGUI()
    {
        // ritar ut hur mycket pengar spelaren har
        GUILayout.BeginArea(new Rect(Screen.width - 180, Screen.height * 0.1f, 150, 250));

        GUILayout.Box("Gold:  " + playerGold);

        GUILayout.EndArea();
    }
}
