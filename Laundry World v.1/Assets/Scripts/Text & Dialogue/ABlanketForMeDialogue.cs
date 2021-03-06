﻿// Script skrivet av Sanna Gustafsson

using UnityEngine;
using System.Collections;

public class ABlanketForMeDialogue : MonoBehaviour {

    public string[] lines;
    public string[] answerButtons;

    bool displayDialogue = false;
    public bool activateQuest = false;
    public bool hasDoneQuest = false;
    bool line1 = false;
    bool line2 = false;
    bool line3 = false;
    bool line4 = false;
    bool line5 = false;
    bool line6 = false;
    bool line7 = false;
    bool line8 = false;
    bool finishedDialogue = false;
    public int reward;
    public PlayerController player;
    private GUIStyle GUIStyle = new GUIStyle();

    private PlayerStats playerStats;

    public TheMotherOfBlobsDialogue previousQuest;

    private ABlanketForMeFinishDialogue finishDialogue;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        finishDialogue = FindObjectOfType<ABlanketForMeFinishDialogue>();
    }

    void Update()
    {
        if (finishDialogue.previousQuest.hasDoneQuest)
        {
            finishDialogue.enabled = true;
        }

        if (activateQuest)
        {
            player.has1Quest = true;
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height - 100, 350, 600));

        GUIStyle.fontSize = 16; // ändra storlek
        GUIStyle.normal.textColor = Color.white; // ändra färg

        if (displayDialogue && line1)
        {
            GUILayout.Label(lines[0] + "\n" + lines[1], GUIStyle);

            if (GUILayout.Button(answerButtons[0]))
            {
                line2 = true;
                line1 = false;
            }

            if (GUILayout.Button(answerButtons[1]))
            {
                line3 = true;
                line1 = false;
            }
        }

        if (line2 && displayDialogue)
        {
            GUILayout.Label(lines[2], GUIStyle);
            finishedDialogue = true;
            TheFudgeMonster.canHurt = true;
            player.canMove = true;
        }
       
        if (line3)
        {
            GUILayout.Label(lines[3], GUIStyle);

            if (GUILayout.Button(answerButtons[2]))
            {
                line3 = false;
                line4 = true;
            }

             if (GUILayout.Button(answerButtons[6]))
             {
                 line3 = false;
                 line8 = true;
             }
        }

        if (line4)
        {
            GUILayout.Label(lines[4], GUIStyle);

             if (GUILayout.Button(answerButtons[3]))
             {
                 line4 = false;
                 line5 = true;
             }
        }

        if (line5)
        {
            GUILayout.Label(lines[5], GUIStyle);

             if (GUILayout.Button(answerButtons[4]))
             {
                 line5 = false;
                 line6 = true;
             }
        }

        if (line6)
        {
            GUILayout.Label(lines[6], GUIStyle);

            if (GUILayout.Button(answerButtons[5]))
            {
                line6 = false;
                line7 = true;
            }

            if (GUILayout.Button(answerButtons[6]))
            {
                line6 = false;
                line8 = true;
            }
        }

        if (line7)
        {
            GUILayout.Label(lines[7] + "\n" + lines[8], GUIStyle);

             if (GUILayout.Button(answerButtons[8]))
             {
                 line7 = false;
                 displayDialogue = false;
                 finishedDialogue = true;
                 TheFudgeMonster.canHurt = true;
                 player.canMove = true;

             }

             if (GUILayout.Button(answerButtons[9]))
             {
                 activateQuest = true;
                 previousQuest.canDoQuest = false;
                 line7 = false;
                 player.canMove = true;
             }
        }

        if (line8)
        {
            GUILayout.Label(lines[9] + "\n" + lines[10], GUIStyle);

            if (GUILayout.Button(answerButtons[7]))
            {
                line8 = false;
                line7 = true;
            }

            if (GUILayout.Button(answerButtons[8]))
            {
                displayDialogue = false;
                line8 = false;
                finishedDialogue = true;
                TheFudgeMonster.canHurt = true;
                player.canMove = true;
            }
        }

        GUILayout.EndArea();

        if (activateQuest) // ritar ut meddelande om pågående quest
        {
            GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.2f, 250, 250));

            if (!hasDoneQuest)
            {
                GUILayout.Box("New Quest: A Blanket for Me");
            }

            if (hasDoneQuest)
            {
                GUILayout.Box("Quest completed: A Blanket for Me");
            }

            GUILayout.EndArea();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!activateQuest && !hasDoneQuest && !finishedDialogue && previousQuest.activateQuest)
            // kan bara startas om man fått The Mother of Blobs-questet
            {
                line1 = true;
            }

            player.canMove = false;
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
        }
    }

    void QuestCompleted()
    {
        // lägger till reward (om questet har det) till spelarens "pengar"
        PlayerPurse.playerGold += reward;
    }
}

