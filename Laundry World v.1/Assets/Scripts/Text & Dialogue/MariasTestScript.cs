// Grundkod av Sanna Gustafsson
// Modifierat av Maria Görman

using UnityEngine;
using System.Collections;


public class MariasTestScript : MonoBehaviour 
{
	public string[] answerButtons;
	public string[] Questions;
	bool DisplayDialog = false;
	bool ActivateQuest = false;
	public TextBoxManager textManager;
	public PlayerController player;
	public NPCController NPC;

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(700, 600, 400, 400));
        if (DisplayDialog && !ActivateQuest)

        {
            GUILayout.Label(Questions[0]);
            GUILayout.Label(Questions[1]);
            if (GUILayout.Button(answerButtons[0]))
            {
                ActivateQuest = true;
                DisplayDialog = false;
            }
            if (GUILayout.Button(answerButtons[1]))
            {
                DisplayDialog = false;

            }
        }
        if (DisplayDialog && ActivateQuest)
        {
            GUILayout.Label(Questions[2]);
            if (GUILayout.Button(answerButtons[2]))
            {
                DisplayDialog = false;
                player.canMove = true;
            }

        }
        GUILayout.EndArea();
    }

	void OnTriggerEnter()
	{
		DisplayDialog = true;
	}
	void OnTriggerExit()
	{
		DisplayDialog = false;

	}
}
