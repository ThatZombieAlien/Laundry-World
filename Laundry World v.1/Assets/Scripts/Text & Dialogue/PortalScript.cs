// Grundkod av Sanna Gustafsson
// Modifierad av Maria Görman
using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour
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
    bool line11 = false;
    bool line12 = false;
    bool line13 = false;
    bool line14 = false;
    bool line15 = false;
    bool line16 = false;
    bool line17 = false;
    bool line18 = false;
    bool line19 = false;






    //bool finishedDialogue = false;
    //bool talkedAboutHouse = false;
    //bool startedTalking = false;

    bool hasObjects = false;


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

        if (displayDialogue && !activateQuest && line0)        //            && !activateQuest && line1)
        {
            GUILayout.Label(lines[0], guiStyle);
            GUILayout.Label(lines[1], guiStyle);

            if (GUILayout.Button(answerButtons[0]))
            {
                line2 = true;
                line0 = false;

            }

            if (GUILayout.Button(answerButtons[19]))
            {
                displayDialogue = false;
            }

        }

        if (line2)
        {
            GUILayout.Label(lines[2], guiStyle);

            if (GUILayout.Button(answerButtons[1]))
            {
                line2 = false;
                line3 = true;
            }


        }

        if (line3)
        {
            GUILayout.Label(lines[3], guiStyle);

            if (GUILayout.Button(answerButtons[2]))
            {
                line3 = false;
                line4 = true;
            }

            if (GUILayout.Button(answerButtons[3]))
            {
                line3 = false;
                line5 = true;


            }
        }

        if (line4)
        {
            GUILayout.Label(lines[4], guiStyle);

            if (GUILayout.Button(answerButtons[4]))
            {
                line4 = false;
                activateQuest = true;
                displayDialogue = false;

            }
        }


        if (line5)
        {
            GUILayout.Label(lines[5], guiStyle);


            if (GUILayout.Button(answerButtons[5]))
            {
                line5 = false;
                line7 = true;
                activateQuest = true;

            }

        }

        //om man har föremålen
        if (hasObjects && displayDialogue && line7)
        {
            GUILayout.Label(lines[7], guiStyle);

            if (GUILayout.Button(answerButtons[6]))
            {
                line8 = true;
                line7 = false;

            }

        }


        if (line8)
        {
            GUILayout.Label(lines[8], guiStyle);

            if (GUILayout.Button(answerButtons[7]))
            {
                line8 = false;
                line9 = true;
            }

        }


        if (line9)
        {
            GUILayout.Label(lines[9], guiStyle);
            GUILayout.Label(lines[10], guiStyle);

            if (GUILayout.Button(answerButtons[8]))
            {
                line8 = false;
                line9 = false;
                line10 = true;

            }

        }


        if (line10)
        {
            GUILayout.Label(lines[10], guiStyle);

            if (GUILayout.Button(answerButtons[9]))
            {
                line10 = false;
                line11 = true;

            }

        }

        if (line11)
        {
            GUILayout.Label(lines[11], guiStyle);

            if (GUILayout.Button(answerButtons[10]))
            {
                line11 = false;
                line12 = true;

            }

        }

        if (line12)
        {
            GUILayout.Label(lines[12], guiStyle);

            if (GUILayout.Button(answerButtons[10]))
            {
                line12 = false;
                line13 = true;

            }

        }

        if (line13)
        {
            GUILayout.Label(lines[13], guiStyle);

            if (GUILayout.Button(answerButtons[11]))
            {
                line12 = false;
                line13 = true;

            }

            if (GUILayout.Button(answerButtons[12]))
            {
                line12 = false;
                line13 = true;

            }

        }

        if (line14)
        {
            GUILayout.Label(lines[14], guiStyle);

            if (GUILayout.Button(answerButtons[13]))
            {
                line14 = false;
                line15 = true;

            }

        }

        if (line15)
        {
            GUILayout.Label(lines[15], guiStyle);

            if (GUILayout.Button(answerButtons[14]))
            {
                line15 = false;
                line16 = true;

            }

        }


        if (line16)
        {
            GUILayout.Label(lines[16], guiStyle);

            if (GUILayout.Button(answerButtons[15]))
            {
                line16 = false;
                line17 = true;

            }

        }


        if (line16)
        {
            GUILayout.Label(lines[16], guiStyle);

            if (GUILayout.Button(answerButtons[15]))
            {
                line16 = false;
                line17 = true;

            }

        }

        if (line17)
        {
            GUILayout.Label(lines[17], guiStyle);

            if (GUILayout.Button(answerButtons[16]))
            {
                line17 = false;
                line18 = true;

            }

        }

        if (line18)
        {
            GUILayout.Label(lines[18], guiStyle);
            GUILayout.Label(lines[19], guiStyle);

            if (GUILayout.Button(answerButtons[17]))
            {
                line18 = false;
                displayDialogue = false;


            }

            if (GUILayout.Button(answerButtons[18]))
            {
                line18 = false;
                displayDialogue = false;



            }

        }


        if (activateQuest && hasDoneQuest && displayDialogue)
        {
            GUILayout.Label(lines[12], guiStyle);

            if (GUILayout.Button(answerButtons[8]))
            {
                line12 = false;
                line8 = true;
                activateQuest = false;
                PlayerPurse.playerGold += reward;

                playerStats.AddExperience(20);
                displayDialogue = false;

            }

            if (GUILayout.Button(answerButtons[7]))
            {
                displayDialogue = false;
            }
        }

        //        if (line3)
        //        {
        //            GUILayout.Label(lines[3], guiStyle);
        //
        //            if (GUILayout.Button(answerButtons[0]))
        //            {
        //                displayDialogue = false;;
        //                line3 = false;
        //            }
        //        }

        GUILayout.EndArea();

        if (activateQuest) // ritar ut meddelande om pågående quest
        {
            if (player.has1Quest)
            {
                GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.25f, 250, 250));

                if (!hasDoneQuest)
                {
                    GUILayout.Box("New Quest: Find a way to open the portal");
                }

                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest Completed: Find a way to open the portal");
                }
                GUILayout.EndArea();
            }
            else
            {
                GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.2f, 250, 250));

                if (!hasDoneQuest)
                {
                    GUILayout.Box("New Quest: Find a way to open the portal");
                }

                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest Completed: Find a way to open the portal");
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
        }
    }

    //void QuestCompleted()
    //{
    //    // lägger till reward (om questet har det) till spelarens "pengar"
    //    PlayerPurse.playerGold += reward;
    //}

}