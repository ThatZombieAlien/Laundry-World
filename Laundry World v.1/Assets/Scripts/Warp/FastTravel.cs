using UnityEngine;
using System.Collections;

public class FastTravel : MonoBehaviour {

    public PlayerController player;
    Transform warpTarget;
    public Transform warpTarget0;
    //public Transform warpTarget1;
    //public Transform warpTarget2;
    //public Transform warpTarget3;

    public string[] travel;
    public string[] destinations;

    
    // skriv in alla fast travel destinations
    // 0 = 
    // 1 =
    // 2 =
    // 3 = 

    bool displayTravel = false;

    void OnGUI()
    {

        GUILayout.BeginArea(new Rect(Screen.width / 2, Screen.height/2, 350, 500));

        if (displayTravel)
        {
            GUILayout.Label(travel[0]); // Frågar vart man vill åka

            if (GUILayout.Button(destinations[0])) // Knapp 0 syftar på destination 0
            {
                ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
                StartCoroutine(sf.FadeToBlack());
                displayTravel = false;
                player.gameObject.transform.position = warpTarget0.position; // här väljer man target
                Camera.main.transform.position = warpTarget0.position;
                StartCoroutine(sf.FadeToClear());

            }
        }

        GUILayout.EndArea();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            displayTravel = true;
        }
        Debug.Log("Fast Travel!");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            displayTravel = false;
        }
    }
}
