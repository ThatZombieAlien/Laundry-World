using UnityEngine;
using System.Collections;

public class TheMotherOfBlobsDialogue : MonoBehaviour {

public string[] lines;
    public string[] answerButtons;

    bool displayDialogue = false;
    public bool activateQuest = false;
    public bool hasDoneQuest = false;
    bool line2 = false;
    bool line1 = true;
    bool line3 = false;
    bool line4 = false;
    bool line5 = false;
    bool line6 = false;
    bool line7 = false;
    public int reward;
    public PlayerController player;
    public NPCController npc;
    private GUIStyle guiStyle = new GUIStyle();

    private PlayerStats playerStats;

    private TheThreatQuestDialogue theThreatQuestdialogue;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        theThreatQuestdialogue = FindObjectOfType<TheThreatQuestDialogue>();

        //Om man inte har gjort The Threat-questen inaktiveras scriptet
        if (!theThreatQuestdialogue.hasDoneQuest)
        {
            this.enabled = false;
        }
    }

    void Update()
    {
        if (displayDialogue && !activateQuest && !hasDoneQuest)
        {
            player.canMove = false;
            npc.canMove = false;
        }
        if (!displayDialogue)
        {
            player.canMove = true;
            npc.canMove = true;
        }
        if (displayDialogue && hasDoneQuest)
        {
            player.canMove = false;
            npc.canMove = false;
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height - 100, 350, 600));

        guiStyle.fontSize = 16; // ändra storlek
        guiStyle.normal.textColor = Color.white; // ändra färg

        if (displayDialogue && line1)
        {
            GUILayout.Label(lines[0] + "\n" + lines[1], guiStyle); 

            if (GUILayout.Button(answerButtons[0]))
            {
                displayDialogue = false;
            }

            if (GUILayout.Button(answerButtons[1]))
            {
                line2 = true;
                line1 = false;
            }

        }

        if (line2)
        {
            GUILayout.Label(lines[2] + "\n" + lines[3], guiStyle);

            if (GUILayout.Button(answerButtons[2]))
            {
                line3 = true;
                line2 = false;
            }

            if (GUILayout.Button(answerButtons[3]))
            {
                line4 = true;
                line2 = false;
            }
        }

        if (line3)
        {
            GUILayout.Label(lines[5], guiStyle);
            
            if(GUILayout.Button(answerButtons[4]))
            {
                line5 = true;
                line3 = false;
            }

            if (GUILayout.Button(answerButtons[7]))
            {
                displayDialogue = false;
                line3 = false;
            }
        }

        if (line4)
        {
            GUILayout.Label(lines[4] + "\n" + lines[5], guiStyle);

            if (GUILayout.Button(answerButtons[4]))
            {
                line5 = true;
                line4 = false;
            }

            if (GUILayout.Button(answerButtons[7]))
            {
                displayDialogue = false;
                line4 = false;
            }
        }

        if (line5)
        {
            GUILayout.Label(lines[6], guiStyle);
           
            if (GUILayout.Button(answerButtons[5]))
            {
                line6 = true;
                line5 = false;
            }
        }

        if (line6)
        {
            GUILayout.Label(lines[7] + "\n" + lines[8], guiStyle);

            if (GUILayout.Button(answerButtons[6]))
            {
                line6 = false;
                line7 = true;
            }

            if (GUILayout.Button(answerButtons[7]))
            {
                line6 = false;
                displayDialogue = false;
            }
        }

        if (line7)
        {
            GUILayout.Label(lines[9] + "\n" + lines[10], guiStyle);

            if (GUILayout.Button(answerButtons[8]))
            {
                line7 = false;
                displayDialogue = false;
                activateQuest = true;
            }

            if (GUILayout.Button(answerButtons[7]))
            {
                line7 = false;
                displayDialogue = false;
            }
        }

        GUILayout.EndArea();

        if (activateQuest) // ritar ut meddelande om pågående quest
        {
            //GUI.DrawTexture(new Rect(10, 10, 200, 150), texture1);
            GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.2f, 250, 250)); 

            GUILayout.Box("New Quest: The Mother of Blobs");

            GUILayout.EndArea();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
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
        PlayerPurse.playerGold += reward;
    }
}

