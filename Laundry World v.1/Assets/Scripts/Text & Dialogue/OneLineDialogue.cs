// Script skrivet av Sanna Gustafsson

using UnityEngine;
using System.Collections;

public class OneLineDialogue : MonoBehaviour {

    public string[] lines;

    bool displayDialogue = false;

    public NPCController NPC;

    private GUIStyle guiStyle = new GUIStyle();

	void Start () 
    {
	
	}
	
	void Update () 
    {
        if (displayDialogue)
        {
            NPC.canMove = false;
        }
        else
        {
            NPC.canMove = true;
        }	
	}

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height - 100, 350, 500));

        guiStyle.fontSize = 16;
        guiStyle.normal.textColor = Color.white;
        if (displayDialogue)
        {
            GUILayout.Label(lines[0], guiStyle);
        }



        GUILayout.EndArea();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //if (Input.GetKeyDown(KeyCode.E))
            {
                displayDialogue = true;
                Debug.Log("An object Collided");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            displayDialogue = false;
        }
    }
}
