﻿// Grundkod av Sanna Gustafsson
// Modifierat av Nicolina Christiansson

using UnityEngine;
using System.Collections;

public class BorgmästerQuestDialog : MonoBehaviour {


    public string[] lines;
    public string[] answerButtons;

    //public bool destoryOnFinish;
    public bool displayDialogue = false;
    public bool activateQuest = false;
    public bool hasDoneQuest = false;
    bool line2 = false;
    bool line1 = true;
    bool line3 = false;
    bool line4 = false;
    //bool finishedDialogue = false;
    public int reward;
    public TextBoxManager textManager;
    public PlayerController player;
    public NPCController npc;
    private GUIStyle guiStyle = new GUIStyle();

    private PlayerStats playerStats;
    //private PlayerPurse playerReward;



    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
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

        if (displayDialogue && !activateQuest && line1)  ///Första dialogen
        {

            GUILayout.Label(lines[0], guiStyle);

            if (GUILayout.Button(answerButtons[0]))
            {
                line2 = true;
                displayDialogue = true;
                line1 = false;
            }

            if (GUILayout.Button(answerButtons[1]))
            {
                displayDialogue = false;
            }
        }

        if (line2 && displayDialogue)   ///Andra dialogen
        {
            displayDialogue = true;
            GUILayout.Label(lines[1], guiStyle);

            if (GUILayout.Button(answerButtons[2]))
            {
                displayDialogue = true;
                line3 = true;
                line2 = false;
            }

            if (GUILayout.Button(answerButtons[1]))
            {
                displayDialogue = false;
                line2 = false;
            }
        }

        if (line3 && displayDialogue)   //Tredje dialogen
        {
            displayDialogue = true;
            GUILayout.Label(lines[2], guiStyle);

            if (GUILayout.Button(answerButtons[3]))
            {
                activateQuest = true;
                displayDialogue = false;
                line3 = false;
            }

            if (GUILayout.Button(answerButtons[1]))
            {
                displayDialogue = false;
                line3 = false;
            }
        }

        if (activateQuest && hasDoneQuest && displayDialogue)
        {
            GUILayout.Label(lines[3], guiStyle);

            if (GUILayout.Button(answerButtons[3]))
            {
                displayDialogue = false;
                line1 = false;
                activateQuest = false;
                PlayerPurse.playerGold += 150;

                playerStats.AddExperience(20);
               
            }

        }



        GUILayout.EndArea();

        if (activateQuest) // ritar ut meddelande om pågående quest
        {
            if (player.has1Quest)
            {
                GUILayout.BeginArea(new Rect(Screen.width - 350, Screen.height * 0.2f, 250, 250));

                if (!hasDoneQuest)
                {
                    GUILayout.Box("New Quest: Clean the well");
                }

                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest Completed: Clean the well");
                }

                GUILayout.EndArea();
            }
            else
            {
                GUILayout.BeginArea(new Rect(Screen.width - 350, Screen.height * 0.2f, 250, 250));

                if (!hasDoneQuest)
                {
                    GUILayout.Box("New Quest: Clean the well");
                }

                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest Completed: Clean the well");
                }

                GUILayout.EndArea();
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
