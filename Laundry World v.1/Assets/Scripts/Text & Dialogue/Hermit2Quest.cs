using UnityEngine;
using System.Collections;

public class Hermit2Quest : MonoBehaviour {


	// OBS: Endast exempel på struktur
	public string[] lines;
	public string[] answerButtons;

	public bool destoryOnFinish;
	bool displayDialogue = false;
	public bool activateQuest = false;
	public bool hasDoneQuest = false;

	bool line0 = true;
	bool line1 = false;
	bool line2 = false;
	bool line3 = false;
	bool line9 = false;
	bool line10 = false;


	bool finishedDialogue = false;
	public int reward;
	public TextBoxManager textManager;
	public PlayerController player;
	public NPCController npc;
	private GUIStyle guiStyle = new GUIStyle();

	private PlayerStats playerStats;



	void Start()
	{
		//textManager = FindObjectOfType<TextBoxManager>();
		playerStats = FindObjectOfType<PlayerStats>();
	}

	void Update()
	{
		if (displayDialogue && !activateQuest && !hasDoneQuest)
		{
			//textManager.EnableTextBox();
			player.canMove = false;
			npc.canMove = false;
		}
		if (!displayDialogue)
		{
			//textManager.DisableTextBox();
			player.canMove = true;
			npc.canMove = true;
		}
		if (displayDialogue && hasDoneQuest)
		{
			//textManager.EnableTextBox();
			player.canMove = false;
			npc.canMove = false;
		}

	}

	void OnGUI()
	{

		GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height - 100, 350, 600));

		guiStyle.fontSize = 16; // ändra storlek
		guiStyle.normal.textColor = Color.white; // ändra färg

		if (displayDialogue)
//			&& !activateQuest && line1)
		{
			if (activateQuest)
			{
				GUILayout.Label(lines[12], guiStyle);

				if (GUILayout.Button(answerButtons[7]))
				{
					displayDialogue = false;
				}
			}

			if (!activateQuest)
			{
				if (line0) 
				{
					GUILayout.Label (lines [0], guiStyle);

					if (GUILayout.Button (answerButtons [0])) 
					{
						line1 = true;
						line0 = false;
					}
					if (GUILayout.Button (answerButtons [7])) 
					{
						displayDialogue = false;

					}
				}

				if (line1)
				{
			GUILayout.Label(lines[1], guiStyle);

			if (GUILayout.Button(answerButtons[1]))
			{
//				activateQuest = true;
				line1 = false;
				line2 = true;
			}

			if (GUILayout.Button(answerButtons[3]))
			{
				line1 = false;
				line9 = true;
			

			}
		}

				if (line2)
				{
					GUILayout.Label(lines[2], guiStyle);

					if (GUILayout.Button(answerButtons[2]))
					{
						//				activateQuest = true;
						line2 = false;
						line3 = true;
					}

					if (GUILayout.Button(answerButtons[4]))
					{
						line2 = false;
						line9 = true;

					}
				}

				if (line9)
				{
					GUILayout.Label(lines[9], guiStyle);
					GUILayout.Label(lines[10], guiStyle);


					if (GUILayout.Button(answerButtons[2]))
					{
						//				activateQuest = true;
						line2 = false;
						line3 = true;
					}

					if (GUILayout.Button(answerButtons[4]))
					{
						line2 = false;
						line9 = true;

					}
				}

		if (activateQuest && hasDoneQuest && displayDialogue)
		{
			GUILayout.Label(lines[2], guiStyle);

			if (GUILayout.Button(answerButtons[2]))
			{
				displayDialogue = false;
				line3 = true;
				line1 = false;
				activateQuest = false;
				PlayerPurse.playerGold += reward;

				playerStats.AddExperience(20);
			}

			if (GUILayout.Button(answerButtons[3]))
			{
				displayDialogue = false;
			}
		}

		if (line3)
		{
			GUILayout.Label(lines[3], guiStyle);

			if (GUILayout.Button(answerButtons[0]))
			{
				displayDialogue = false;;
				line3 = false;
			}
		}

		GUILayout.EndArea();

		if (activateQuest) // ritar ut meddelande om pågående quest
		{
			//GUI.DrawTexture(new Rect(10, 10, 200, 150), texture1);
			GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.2f, 250, 250)); // "putta ner quests beroende på hur många man har?

			GUILayout.Box("New Quest: Find the book"); // sätt in bools för vilken text som ska visas beroende på vilket quest man är på?

			GUILayout.EndArea();
		}

	}
	}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player")
		{
			//if (Input.GetKeyDown(KeyCode.E))
			{
				if (!activateQuest && !hasDoneQuest)
				{
					line1 = true;
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

	void QuestCompleted()
	{
		// lägger till reward (om questet har det) till spelarens "pengar"
		PlayerPurse.playerGold += reward;
	}
}

