﻿// Script skrivet av Sanna Gustafsson

using UnityEngine;
using System.Collections;

public class QuestDialogue : MonoBehaviour {

    public string[] lines;
    public string[] answerButtons;

    public bool destoryOnFinish;
    bool displayDialogue = false;
    public bool activateQuest = false;
    public bool hasDoneQuest = false;
    bool line2 = false;
    bool line1 = true;
    bool line3 = false;
    bool line4 = false;
    bool finishedDialogue = false;
    public int reward;
    public TextBoxManager textManager;
    public PlayerController player;
    public NPCController NPC;
    private GUIStyle GUIStyle = new GUIStyle();

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        if (displayDialogue && !activateQuest && !hasDoneQuest)
        {
            player.canMove = false;
            NPC.canMove = false;
        }

        if (displayDialogue && hasDoneQuest)
        {
            player.canMove = false;
            NPC.canMove = false;
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height - 100, 350, 600));

        GUIStyle.fontSize = 16; // ändra storlek
        GUIStyle.normal.textColor = Color.white; // ändra färg

        if (displayDialogue && !activateQuest && line1)
        {
            GUILayout.Label(lines[0], GUIStyle);

            if (GUILayout.Button(answerButtons[0]))
            {
                line2 = true;
                displayDialogue = true;
                line1 = false;
            }

            if (GUILayout.Button(answerButtons[3]))
            {
                displayDialogue = false;
                player.canMove = true;
            }
        }

        if (line2 && displayDialogue)
        {
            displayDialogue = true;
            GUILayout.Label(lines[1], GUIStyle);

            if (GUILayout.Button(answerButtons[1]))
            {
                activateQuest = true;
                displayDialogue = false;
                line1 = true;
                line2 = false;
            }

            if (GUILayout.Button(answerButtons[4]))
            {
                displayDialogue = false;
                line4 = true;
                line2 = false;
            }


            if (GUILayout.Button(answerButtons[3]))
            {
                displayDialogue = false;
                line2 = false;
                player.canMove = true;
            }
        }

        if (activateQuest && hasDoneQuest && displayDialogue)
        {
            GUILayout.Label(lines[2], GUIStyle);

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
                player.canMove = true;
            }
        }

        if (line3)
        {
            GUILayout.Label(lines[3], GUIStyle);

            if (GUILayout.Button(answerButtons[0]))
            {
                displayDialogue = false;;
                line3 = false;
                player.canMove = true;
            }
        }

        if (line4)
        {
            GUILayout.Label(lines[4], GUIStyle);

            if (GUILayout.Button(answerButtons[1]))
            {
                activateQuest = true;
                displayDialogue = false;
                line4 = false;
                player.canMove = true;
            }
        }
       
        GUILayout.EndArea();

        if (activateQuest) // ritar ut meddelande om pågående quest
        {
            if (player.has1Quest)
            {
                GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.2f, 250, 250));

                if (!hasDoneQuest)
                {
                    GUILayout.Box("New Quest: Find the book");
                }
                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest Completed: Find the book");
                }
                GUILayout.EndArea();
            }
            else
            {
                GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.2f, 250, 250));

                if (!hasDoneQuest)
                {
                    GUILayout.Box("New Quest: Find the book");
                }
                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest Completed: Find the book");
                }
                GUILayout.EndArea();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!activateQuest && !hasDoneQuest)
            {
                line1 = true;
            }

            displayDialogue = true;
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

    void QuestCompleted()
    {
        // lägger till reward (om questet har det) till spelarens "pengar"
        PlayerPurse.playerGold += reward;
    }
}

