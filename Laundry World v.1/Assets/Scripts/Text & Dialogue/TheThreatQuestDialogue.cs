﻿// Grundkod av Sanna Gustafsson
// Modifierat av Anna Englund

using UnityEngine;
using System.Collections;

public class TheThreatQuestDialogue : MonoBehaviour 
{
    public string[] lines;
    public string[] answerButtons;

    bool displayDialogue = false;
    public bool activateQuest = false;
    public bool hasDoneQuest = false;
    public bool haveSpoken = false;
    bool line0 = false;
    bool line1 = false;
    bool line2 = false;
    bool line3 = false;
    bool line4 = false;
    bool line5 = false;
    bool line6 = false;
    bool line7 = false;
    bool line8 = false;
    bool line9 = false;
    bool finishedDialogue = false;
    public int reward;
    public TextBoxManager textManager;
    public PlayerController player;
    public NPCController NPC;
    private GUIStyle GUIStyle = new GUIStyle();

    private PlayerStats playerStats;
    private TheMotherOfBlobsDialogue questDialogue;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        questDialogue = FindObjectOfType<TheMotherOfBlobsDialogue>();
    }

    void Update()
    {
        if (displayDialogue && !activateQuest && !hasDoneQuest)
        {
            player.canMove = false;
        }

        if (displayDialogue && hasDoneQuest)
        {
            player.canMove = false;
        }

        if (hasDoneQuest)
        {
            questDialogue.enabled = true;
        }

        if (activateQuest)
        {
            player.has1Quest = true;
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height - 100, 350, 600));

        GUIStyle.fontSize = 16;
        GUIStyle.normal.textColor = Color.white;

        if (displayDialogue && !activateQuest && line0)
        {

            GUILayout.Label(lines[0], GUIStyle);

            if (GUILayout.Button(answerButtons[0]))
            {
                line1 = true;
                line0 = false;
            }

            if (GUILayout.Button(answerButtons[1]))
            {
                line0 = false;
                line1 = false;
                line5 = true;
                line4 = true;
                displayDialogue = false;
            }
        }

        if (line1)
        {
            GUILayout.Label(lines[1], GUIStyle);

            if (GUILayout.Button(answerButtons[2]))
            {
                line1 = false;
                line2 = true;
                displayDialogue = false;
            }

            if (GUILayout.Button(answerButtons[3]))
            {
                line5 = true;
                line4 = true;
                line1 = false;
            }
        }

        if(line2)
        {
            GUILayout.Label(lines[2], GUIStyle);
            
            if (GUILayout.Button(answerButtons[4]))
            {
                line3 = true;
                line4 = true;
                line2 = false;
            }

            if (GUILayout.Button(answerButtons[5]))
            {
                line3 = true;
                line4 = true;
                line2 = false;
            }
        }

        if(line3 && line4)
        {
            GUILayout.Label(lines[3], GUIStyle);
            GUILayout.Label(lines[4], GUIStyle);

            if (GUILayout.Button(answerButtons[6]))
            {
                line7 = true;
                line8 = true;
                line4 = false;
                line3 = false;
            }

            if (GUILayout.Button(answerButtons[7]))
            {
                line6 = true;
                line4 = false;
                line3 = false;
            }
        }

        if (line4 && line5)
        {
            GUILayout.Label(lines[5], GUIStyle);
            GUILayout.Label(lines[4], GUIStyle);

            if (GUILayout.Button(answerButtons[6]))
            {
                line7 = true;
                line8 = true;
                line4 = false;
                line5 = false;
            }

            if (GUILayout.Button(answerButtons[7]))
            {
                line6 = true;
                line4 = false;
                line5 = false;
            }
        }

        if(line6)
        {
            GUILayout.Label(lines[6], GUIStyle);

            if (GUILayout.Button(answerButtons[9]))
            {
                line6 = false;
                player.canMove = true;
            }
        }

        if(line7 && line8)
        {
            GUILayout.Label(lines[7], GUIStyle);
            GUILayout.Label(lines[8], GUIStyle);

            if (GUILayout.Button(answerButtons[6]))
            {
                activateQuest = true;
                haveSpoken = true;
                line7 = false;
                line8 = false;
            }

            if (GUILayout.Button(answerButtons[8]))
            {
                line6 = true;
                line7 = false;
                line8 = false;
            }
        }

        if (line9 && line4)
        {
            GUILayout.Label(lines[9], GUIStyle);
            GUILayout.Label(lines[4], GUIStyle);

            if (GUILayout.Button(answerButtons[7]))
            {
                activateQuest = true;
            }

            if (GUILayout.Button(answerButtons[8]))
            {
                line6 = true;
            }
        }

        GUILayout.EndArea();

        if (activateQuest)
        {
            GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.2f, 250, 250));

            if (!hasDoneQuest)
            {
                GUILayout.Box("New Quest: Kill the blobs");
            }

            if (hasDoneQuest)
            {
                GUILayout.Box("Quest completed: Kill the blobs");
            }

            GUILayout.EndArea();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && !ConfrontingNicoDialogue.activateDialogue)
        {
            if (!activateQuest && !hasDoneQuest)
            {
                line0 = true;
            }

            if (!activateQuest && !haveSpoken)
            {
                line0 = true;
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
        PlayerPurse.playerGold += reward;
    }
}