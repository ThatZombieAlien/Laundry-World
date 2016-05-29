// Script skrivet av Sanna Gustafsson

using UnityEngine;
using System.Collections;

public class FastTravel : MonoBehaviour {

    public PlayerController player;
    public bool target0;
    public bool target1;
    public bool target2;
    Transform warpTarget;
    public Transform warpTarget0;
    public Transform warpTarget1;
    public Transform warpTarget2;

    public string[] travel;
    public string[] destinations;
    
    // skriv in alla fast travel destinations
    // 0 = Lake
    // 1 = Village
    // 2 = Hermit Hut

    bool displayTravel = false;
    private GUIStyle guiStyle = new GUIStyle();

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2, Screen.height/2, 350, 500));

        guiStyle.fontSize = 16; // ändra storlek
        guiStyle.normal.textColor = Color.white; // ändra färg

        if (displayTravel)
        {
            GUILayout.Label(travel[0], guiStyle); // Frågar vart man vill åka

            if (FastTravelPointManager.target0Found && !target0)
            {
                if (GUILayout.Button(destinations[0])) // Knapp 0 syftar på destination 0
                {
                    ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
                    StartCoroutine(sf.FadeToBlack());
                    displayTravel = false;
                    player.gameObject.transform.position = warpTarget0.position; // här väljer man target
                    UnityEngine.Camera.main.transform.position = warpTarget0.position;
                    StartCoroutine(sf.FadeToClear());
                }
            }

            if (FastTravelPointManager.target1Found && !target1)
            {
                if (GUILayout.Button(destinations[1]))
                {
                    ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
                    StartCoroutine(sf.FadeToBlack());
                    displayTravel = false;
                    player.gameObject.transform.position = warpTarget1.position;
                    UnityEngine.Camera.main.transform.position = warpTarget1.position;
                    StartCoroutine(sf.FadeToClear());
                }
            }

            if (FastTravelPointManager.target2Found && !target2)
            {
                if (GUILayout.Button(destinations[2]))
                {
                    ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
                    StartCoroutine(sf.FadeToBlack());
                    displayTravel = false;
                    player.gameObject.transform.position = warpTarget2.position;
                    UnityEngine.Camera.main.transform.position = warpTarget2.position;
                    StartCoroutine(sf.FadeToClear());
                }
            }

            if (target0 && !FastTravelPointManager.target1Found && !FastTravelPointManager.target2Found)
            {
                GUILayout.Box("You haven't found any Fast Travel-points yet!");
            }

            if (target1 && !FastTravelPointManager.target0Found && !FastTravelPointManager.target2Found)
            {
                GUILayout.Box("You haven't found any Fast Travel-points yet!");
            }

            if (target2 && !FastTravelPointManager.target1Found && !FastTravelPointManager.target0Found)
            {
                GUILayout.Box("You haven't found any Fast Travel-points yet!");
            }
        }

        GUILayout.EndArea();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (target0)
        {
            FastTravelPointManager.target0Found = true;
        }

        if (target1)
        {
            FastTravelPointManager.target1Found = true;
        }

        if (target2)
        {
            FastTravelPointManager.target2Found = true;
        }
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
