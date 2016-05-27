// Grundkod av Sanna Gustafsson
// Modifierat av 

using UnityEngine;
using System.Collections;

public class Hermit2Quest : MonoBehaviour
{

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
    bool line4 = false;
    bool line5 = false;
    bool line6 = false;
    bool line7 = false;
    bool line8 = false;
    bool line9 = false;
    bool line10 = false;
    bool line12 = false;
    bool line13 = false;


    bool finishedDialogue = false;
    bool talkedAboutHouse = false;
    bool startedTalking = false;


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

        if (displayDialogue && !activateQuest && line0)        //            && !activateQuest && line1)
        {
            GUILayout.Label(lines[0], GUIStyle);

            //            startedTalking = true;

            if (GUILayout.Button(answerButtons[0]))
            {
                line1 = true;
                displayDialogue = true;
                line0 = false;
            }

            if (GUILayout.Button(answerButtons[7]))
            {
                displayDialogue = false;
                player.canMove = true;
            }

        }

        if (line1 && displayDialogue)
        {
            if (line0)
            {
                GUILayout.Label(lines[0], GUIStyle);

                if (GUILayout.Button(answerButtons[0]))
                {
                    line1 = true;
                    line0 = false;
                }
                if (GUILayout.Button(answerButtons[7]))
                {
                    displayDialogue = false;
                    player.canMove = true;

                }
            }
        }

        if (line1)
        {
            GUILayout.Label(lines[1], GUIStyle);

            if (GUILayout.Button(answerButtons[1]))
            {
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
            GUILayout.Label(lines[2], GUIStyle);

            if (GUILayout.Button(answerButtons[2]))
            {
                line2 = false;
                line3 = true;
            }

            if (GUILayout.Button(answerButtons[4]))
            {
                line2 = false;
                line5 = true;

            }
        }
        if (line3)
        {
            GUILayout.Label(lines[3], GUIStyle);

            if (GUILayout.Button(answerButtons[4]))
            {
                line5 = true;
                line3 = false;
            }
        }

        if (line9)
        {
            GUILayout.Label(lines[9], GUIStyle);
            GUILayout.Label(lines[10], GUIStyle);


            if (GUILayout.Button(answerButtons[2]))
            {
                line9 = false;
                line3 = true;
            }

            if (GUILayout.Button(answerButtons[4]))
            {
                line5 = true;
                line9 = false;

            }
        }


        if (line5)
        {
            GUILayout.Label(lines[5], GUIStyle);
            GUILayout.Label(lines[6], GUIStyle);


            if (GUILayout.Button(answerButtons[5]))
            {
                line5 = false;
                line7 = true;
            }

        }


        if (line7)
        {
            GUILayout.Label(lines[7], GUIStyle);

            if (GUILayout.Button(answerButtons[6]))
            {
                activateQuest = true;
                line7 = false;
                line8 = true;
            }

        }

        if (line8)
        {
            GUILayout.Label(lines[8], GUIStyle);

            if (GUILayout.Button(answerButtons[7]))
            {
                line8 = false;

                displayDialogue = false;
                player.canMove = true;
            }

        }



        if (activateQuest && hasDoneQuest && displayDialogue)
        {
            GUILayout.Label(lines[12], GUIStyle);

            if (GUILayout.Button(answerButtons[8]))
            {
                line12 = false;
                line8 = true;
                activateQuest = false;
                PlayerPurse.playerGold += reward;

                playerStats.AddExperience(20);
                displayDialogue = false;
                player.canMove = true;

            }

            if (GUILayout.Button(answerButtons[7]))
            {
                displayDialogue = false;
                player.canMove = true;
            }
        }

        GUILayout.EndArea();

        if (activateQuest) // ritar ut meddelande om pågående quest
        {
            if (player.has1Quest)
            {
                GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.25f, 250, 250));

                if (!hasDoneQuest)
                {
                    GUILayout.Box("New Quest: Find building material");
                }

                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest Completed: Find building material");
                }
                GUILayout.EndArea();
            }
            else
            {
                GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.2f, 250, 250));

                if (!hasDoneQuest)
                {
                    GUILayout.Box("New Quest: Find building material");
                }

                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest Completed: Find building material");
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
                    line0 = true;
                }
                //
                //                if (!activateQuest && !hasDoneQuest)  //&& talkedAboutHouse && startedTalking
                //                {
                //                    Debug.Log("blurb");
                //
                //                    line3 = true;
                //                
                //                }

                displayDialogue = true;
                //Debug.Log("An object Collided");
            }

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



