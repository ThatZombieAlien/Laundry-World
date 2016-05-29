// Grundkod av Sanna Gustafsson
// Modifierat av Maria Görman

using UnityEngine;
using System.Collections;

public class MariasDialogue : MonoBehaviour {

	public string[] lines;
	public string[] answerButtons;

	bool displayDialogue = false;
	bool activateQuest = false;
	bool exitDialogue = false;
	bool line0 = true;
	bool line1 = false;
	bool line2 = false;
	bool line3 = false;
	bool line4 = false;
	bool line5 = false;
	bool line6 = false;
	bool line7 = false;
	bool line8 = false;

	public TextBoxManager textManager;
	public PlayerController player;
	public NPCController NPC;

	private GUIStyle GUIStyle = new GUIStyle();

	void Update () 
	{
		if (displayDialogue)
		{
			player.canMove = false;
			NPC.canMove = false;
		}
	}

	void OnGUI()
	{
		GUILayout.BeginArea (new Rect (Screen.width / 2 - 150, Screen.height - 100, 350, 500));

		GUIStyle.fontSize = 16; // ändra storlek
		GUIStyle.normal.textColor = Color.white; // ändra färg

		if (exitDialogue)
		{
			textManager.DisableTextBox ();
		}

		if (displayDialogue)
		{
			if (activateQuest)
			{
				GUILayout.Label(lines[9], GUIStyle);

				if (GUILayout.Button(answerButtons[8]))
				{
					displayDialogue = false;
                    player.canMove = true;
				}
			}
			if (!activateQuest) 
			{
				if (line0) 
				{
					GUILayout.Label (lines [0], GUIStyle);

					if (GUILayout.Button (answerButtons [0])) 
					{
						line1 = true;
						line0 = false;
					}
					if (GUILayout.Button (answerButtons [5])) 
					{
						line4 = true;
						line0 = false;
					}
				}

				if (line1) 
				{
					GUILayout.Label (lines [1], GUIStyle);

					if (GUILayout.Button (answerButtons [1]))
					{
						line2 = true;
						line1 = false;
					}
					if (GUILayout.Button (answerButtons [2]))
					{
						line7 = true;
						line1 = false;
					}
				}
				if (line2) 
				{
					GUILayout.Label (lines [2], GUIStyle);

					if (GUILayout.Button (answerButtons [4]))
					{
						line3 = true;
						line2 = false;
					}
					if (GUILayout.Button (answerButtons [3])) 
					{
						line4 = true;
						line2 = false;
					}
				}

				if (line3) {
					GUILayout.Label (lines [3], GUIStyle);

					if (GUILayout.Button (answerButtons [3])) 
					{
						line4 = true;
						line3 = false;
					}
					if (GUILayout.Button (answerButtons [8])) 
					{
						line3 = false;
						displayDialogue = false;
						exitDialogue = true;
                        player.canMove = true;
					}
				}

				if (line4) 
				{
					GUILayout.Label (lines [4], GUIStyle);

					if (GUILayout.Button (answerButtons [6])) 
					{
						line5 = true;
						line4 = false;
					}
				}


				if (line5) 
				{
					GUILayout.Label (lines [5], GUIStyle);

					if (GUILayout.Button (answerButtons [7])) 
					{
						line6 = true;
						line5 = false;
					}
				}


				if (line6) 
				{
					GUILayout.Label (lines [6], GUIStyle);

					if (GUILayout.Button (answerButtons [9])) 
					{
						line8 = true;
						line6 = false;
					}
				}

				if (line7) {
					GUILayout.Label (lines [7], GUIStyle);

					if (GUILayout.Button (answerButtons [3])) 
					{
						line4 = true;
						line7 = false;
					}
					if (GUILayout.Button (answerButtons [8])) 
					{
						line8 = true;
						line7 = false;
					}
				}

				if (line8) 
				{
					GUILayout.Label (lines [8], GUIStyle);

					if (GUILayout.Button (answerButtons [8])) 
					{
						line8 = false;
						displayDialogue = false;
						exitDialogue = true;
						activateQuest = true;
                        player.canMove = true;
					}
				}
			}
	}
		GUILayout.EndArea();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.name == "Player")
        {
            if (!activateQuest)
            {
                line0 = true;
            }
            displayDialogue = true;
            exitDialogue = false;
            Debug.Log("An object Collided");
        }
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "Player")
		{
			displayDialogue = false;
            player.canMove = true;
            NPC.canMove = true;
		}
	}
}
