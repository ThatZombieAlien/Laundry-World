// Grundkod av Sanna Gustafsson
// Modifierat av Maria Görman

using UnityEngine;
using System.Collections;

public class MuckDialogue : MonoBehaviour {
    private Blur blur;

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
	bool line9 = false;
	bool line10 = false;
	bool line11 = false;
	bool line12 = false;
	bool line13 = false;
	bool line14 = false;
	bool line15 = false;
	bool line16 = false;
	bool line17 = false;
	bool line18 = false;
	bool line19 = false;
	bool line20 = false;



	//
	//	bool displayDialogue = false;
	//	bool activateQuest = false;
	//	bool nextLine = false;
	//	bool firstLine = true;

	public TextBoxManager textManager;
	public PlayerController player;
	public NPCController npc;

    private Inventory inventory;

	private GUIStyle guiStyle = new GUIStyle();


	void Start () 
	{
        blur = FindObjectOfType<Blur>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        inventory.backpack.SetActive(false);
    }

	void Update () 
	{
		if (displayDialogue)
		{
			player.canMove = false;
			npc.canMove = false;
		}
	}

	void OnGUI()
	{
		GUILayout.BeginArea (new Rect (Screen.width / 2 - 150, Screen.height - 100, 350, 500));

		guiStyle.fontSize = 16; // ändra storlek
		guiStyle.normal.textColor = Color.white; // ändra färg
		if (exitDialogue) {
			textManager.DisableTextBox ();
		}

        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(EndBlur());
            inventory.backpack.SetActive(true);
            player.canMove = true;
        }
		if (displayDialogue)
		{
			if (activateQuest)
			{
				GUILayout.Label(lines[9], guiStyle);

				if (GUILayout.Button(answerButtons[8]))
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

				}

				if (line1) 
				{
					//			displayDialogue = true;
					GUILayout.Label (lines [1], guiStyle);

					if (GUILayout.Button (answerButtons [1]))
					{
						line2 = true;
						line1 = false;
						//						activateQuest = true;
	
					}
				}
				if (line2) {
					GUILayout.Label (lines [2], guiStyle);

					if (GUILayout.Button (answerButtons [2])) {
						line3 = true;
						line2 = false;
					}
				
				}

				if (line3) {
					GUILayout.Label (lines [3], guiStyle);
					GUILayout.Label (lines [4], guiStyle);

					if (GUILayout.Button (answerButtons [0])) 
					{
						line5 = true;
						line3 = false;
						line4 = false;
					}

				}

				if (line5) 
				{
					GUILayout.Label (lines [5], guiStyle);

                    StartCoroutine(EndBlur());

                    if (GUILayout.Button (answerButtons [3])) 
					{
						line6 = true;
						line5 = false;

					}
				}

			

				if (line6) 
				{
					GUILayout.Label (lines [6], guiStyle);

					if (GUILayout.Button (answerButtons [4])) 
					{
						line7 = true;
						line6 = false;
					}

				}

				if (line7)
				{
					GUILayout.Label (lines [7], guiStyle);

					if (GUILayout.Button (answerButtons [5]))
					{
						line8 = true;
						line7 = false;
					}

				}

				if (line8)
				{
					GUILayout.Label (lines [8], guiStyle);

					if (GUILayout.Button (answerButtons [6]))
					{
						line9 = true;
						line8 = false;
					}

				}

				if (line9)
				{
					GUILayout.Label (lines [9], guiStyle);

					if (GUILayout.Button (answerButtons [7]))
					{
						line10 = true;
						line9 = false;
					}

				}

				if (line10)
				{
					GUILayout.Label (lines [10], guiStyle);

					if (GUILayout.Button (answerButtons [8]))
					{
						line11 = true;

						line10 = false;
					}

				}


				if (line11)
				{
					GUILayout.Label (lines [11], guiStyle);
					GUILayout.Label (lines [12], guiStyle);

					if (GUILayout.Button (answerButtons [0]))
					{
						line12 = true;
						line11 = false;
					}

				}

				if (line12)
				{
					GUILayout.Label (lines [21], guiStyle);

					if (GUILayout.Button (answerButtons [9]))
					{
						line13 = true;

						line12 = false;
					}

				}

				if (line13)
				{
					GUILayout.Label (lines [13], guiStyle);

					if (GUILayout.Button (answerButtons [10]))
					{
						line14 = true;

						line13 = false;
					}

				}

				if (line14)
				{
					GUILayout.Label (lines [14], guiStyle);

					if (GUILayout.Button (answerButtons [11]))
					{
						line15 = true;

						line14 = false;
					}

				}

				if (line15)
				{
					GUILayout.Label (lines [15], guiStyle);

					if (GUILayout.Button (answerButtons [12]))
					{
						line16 = true;

						line15 = false;
					}

				}

				if (line16)
				{
					GUILayout.Label (lines [16], guiStyle);


					if (GUILayout.Button (answerButtons [14]))
					{
						line17 = true;

						line16 = false;
					}

				}

				if (line17)
				{
					GUILayout.Label (lines [17], guiStyle);
					GUILayout.Label (lines [22], guiStyle);


					if (GUILayout.Button (answerButtons [15]))
					{
						line18 = true;

						line17 = false;
					}

				}

				if (line18)
				{
					GUILayout.Label (lines [18], guiStyle);
					GUILayout.Label (lines [19], guiStyle);


					if (GUILayout.Button (answerButtons [13]))
					{
						line19 = true;

						line18 = false;
                        Destroy(gameObject); // sätt på sista svaret
                        inventory.backpack.SetActive(true);
                        player.canMove = true;
					}

				}

//				if (line8) 
//				{
//					GUILayout.Label (lines [8], guiStyle);
//
//					if (GUILayout.Button (answerButtons [6])) 
//					{
//						line8 = false;
//						//						textManager.DisableTextBox ();
//						displayDialogue = false;
//						exitDialogue = true;
//						activateQuest = true;
//					}
//				}

				//
				//		if (!activateQuest && nextLine)
				//		{
				//			displayDialogue = true;
				//			GUILayout.Label(lines[2], guiStyle);
				//
				//			if (GUILayout.Button(answerButtons[4]))
				//			{
				//				activateQuest = true;
				//				displayDialogue = true;
				//			}
				//			if (GUILayout.Button(answerButtons[3]))
				//			{
				//				displayDialogue = false;
				//				nextLine= false;
				//				textManager.DisableTextBox();
				//			}
				//		}


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
					line0 = true;
				}
				displayDialogue = true;
				exitDialogue = false;
				Debug.Log("An object Collided");
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "Player")
		{
			displayDialogue = false;
            player.canMove = true;
            npc.canMove = true;
		}
	}

    public IEnumerator EndBlur()
    {
        yield return new WaitForSeconds(.5f);
        blur.RemoveBlur();
    }
}
