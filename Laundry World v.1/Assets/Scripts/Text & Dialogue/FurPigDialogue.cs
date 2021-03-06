﻿// Grundkod av Sanna Gustafsson
// Modifierat av Nicolina Christiansson

using UnityEngine;
using System.Collections;

public class FurPigDialogue : MonoBehaviour
{

    public string[] lines;
    public string[] answerButtons;

    bool displayDialogue = false;
    public bool activateQuest = false;
    public bool hasDoneQuest = false;
    bool line1 = true;
    bool line2 = false;
    bool line3 = true;
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

    bool finishedDialogue = false;
    public int reward;
    public TextBoxManager textManager;
    public PlayerController player;
    public NPCController npc;
    private GUIStyle guiStyle = new GUIStyle();

    private PlayerStats playerStats;
    private MrSealDialogue mrSealDialogue;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        mrSealDialogue = FindObjectOfType<MrSealDialogue>();
    }

    void Update()
    {
        if (displayDialogue && !activateQuest && !hasDoneQuest)
        {
            player.canMove = true;
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

        if (line3 && displayDialogue && mrSealDialogue.hasTalked) //Replik 1(3) element 0
        {
            displayDialogue = true;
            GUILayout.Label(lines[0], guiStyle);

            if (GUILayout.Button(answerButtons[2]))
            {
                displayDialogue = true;
                line4 = true;
                line3 = false;
            }
        }

        if (line3 && displayDialogue && !mrSealDialogue.hasTalked)
        {
            GUILayout.Label(lines[0], guiStyle);

            if (GUILayout.Button(answerButtons[0]))
            {
                displayDialogue = false;
            }
        }


        if (line4 && displayDialogue) //Replik 2(4) element 2
        {
            displayDialogue = true;
            GUILayout.Label(lines[2], guiStyle);

            if (GUILayout.Button(answerButtons[3]))
            {
                displayDialogue = true;
                line5 = true;
                line4 = false;
            }

            if (GUILayout.Button(answerButtons[4]))
            {
                displayDialogue = true;
                line6 = true;
                line4 = false;
            }
        }

        if (line5 && displayDialogue) //Replik 3(5) element 3
        {
            displayDialogue = true;
            GUILayout.Label(lines[3], guiStyle);

            if (GUILayout.Button(answerButtons[4]))
            {
                displayDialogue = true;
                line6 = true;
                line5 = false;
            }
        }

        if (line6 && displayDialogue)  //Replik 4(6) och 5(7), element 4 och 5
        {
            displayDialogue = true;
            GUILayout.Label(lines[4], guiStyle);
            GUILayout.Label(lines[5], guiStyle);


            if (GUILayout.Button(answerButtons[5]))
            {
                displayDialogue = true;
                line7 = true;
                line6 = false;
            }
        }

        if (line7 && displayDialogue) //Replik 6(8) och 7(9), element 6 och 7
        {
            displayDialogue = true;
            GUILayout.Label(lines[6], guiStyle);
            GUILayout.Label(lines[7], guiStyle);

            if (GUILayout.Button(answerButtons[6]))
            {
                activateQuest = true;
                displayDialogue = true;
                line8 = true;
                line7 = false;
            }
        }

        if (line8 && activateQuest && hasDoneQuest && displayDialogue)  //Replik 8(10) element 1
        {
            GUILayout.Label(lines[1], guiStyle);

            if (GUILayout.Button(answerButtons[7]))
            {
                displayDialogue = true;
                line9 = true;
                line8 = false;
                activateQuest = false;
                playerStats.AddExperience(30);
            }
        }

        if (line9 && displayDialogue) //Replik 9(11) element 8
        {
            displayDialogue = true;
            GUILayout.Label(lines[8], guiStyle);

            if (GUILayout.Button(answerButtons[8]))
            {
                displayDialogue = true;
                line10 = true;
                line9 = false;
            }
        }

        if (line10 && displayDialogue) //Replik 10(12) och 11(13), element 9 och 10
        {
            displayDialogue = true;
            GUILayout.Label(lines[9], guiStyle);
            GUILayout.Label(lines[10], guiStyle);

            if (GUILayout.Button(answerButtons[9]))
            {
                displayDialogue = true;
                line11 = true;
                line10 = false;
            }
        }

        if (line11 && displayDialogue) //Replik 12(14) element 11
        {
            displayDialogue = true;
            GUILayout.Label(lines[11], guiStyle);
            GUILayout.Label(lines[12], guiStyle);

            if (GUILayout.Button(answerButtons[10]))
            {
                displayDialogue = true;
                line12 = true;
                line11 = false;
            }
        }

        if (line12 && displayDialogue) //Replik 13(15) element 12
        {
            displayDialogue = true;
            GUILayout.Label(lines[13], guiStyle);

            if (GUILayout.Button(answerButtons[11]))
            {
                displayDialogue = true;
                line13 = true;
                line12 = false;
            }
        }

        if (line13 && displayDialogue) //Replik 14(16) element 14
        {
            displayDialogue = true;
            GUILayout.Label(lines[14], guiStyle);

            if (GUILayout.Button(answerButtons[12]))
            {
                displayDialogue = true;
                line14 = true;
                line13 = false;
            }
        }

        if (line14 && displayDialogue) //Replik 15(17) element 15
        {
            displayDialogue = true;
            GUILayout.Label(lines[15], guiStyle);

            if (GUILayout.Button(answerButtons[13]))
            {
                displayDialogue = false;
                line13 = false;
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
                    GUILayout.Box("New Quest: Washi washi - Find detergent");
                }
                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest Completed: You found detergent!");
                }
                GUILayout.EndArea();
            }
            else
            {
                GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.2f, 250, 250));

                if (!hasDoneQuest)
                {
                    GUILayout.Box("New Quest: Washi washi - Find detergent");
                }
                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest Completed: You found detergent!");
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
        }
    }

    void QuestCompleted()
    {
        // lägger till reward (om questet har det) till spelarens "pengar"
        PlayerPurse.playerGold += reward;
    }
}
