using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {

    public string[] lines;
    public string[] answerButtons;

    bool displayDialogue = false;
    bool activateQuest = false;
    bool nextLine = false;
    bool firstLine = true;
    public TextBoxManager textManager;
    public PlayerController player;
    public NPCController NPC;


	void Start () 
    {
	}
	
	void Update () 
    {
        if (displayDialogue)
        {
            //textManager.EnableTextBox();
            player.canMove = false;
            NPC.canMove = false;
        }
        else
        {
            //textManager.DisableTextBox();
            player.canMove = true;
            NPC.canMove = true;
        }

	}

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width/2 - 150, Screen.height - 100, 350, 500));

        if (displayDialogue && !activateQuest && firstLine)
        {
            GUILayout.Label(lines[0]);
            
            if (GUILayout.Button(answerButtons[0]))
            {
                nextLine = true;
                displayDialogue = false;
                firstLine = false;
            }
            if (GUILayout.Button(answerButtons[2]))
            {
                displayDialogue = false;
                
            }
        }

        if (!activateQuest && nextLine)
        {
            displayDialogue = true;
            GUILayout.Label(lines[1]);

            if (GUILayout.Button(answerButtons[1]))
            {
                activateQuest = true;
                displayDialogue = true;
            }
            if (GUILayout.Button(answerButtons[2]))
            {
                displayDialogue = false;
                nextLine= false;
                textManager.DisableTextBox();
            }
        }

        if (displayDialogue & activateQuest)
        {
            GUILayout.Label(lines[2]);
            
            if (GUILayout.Button(answerButtons[2]))
            {
                displayDialogue = false;
            }
        }

        GUILayout.EndArea();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //if (Input.GetKeyDown(KeyCode.E))
            {
                if (!activateQuest)
                {
                    firstLine = true;
                }
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
