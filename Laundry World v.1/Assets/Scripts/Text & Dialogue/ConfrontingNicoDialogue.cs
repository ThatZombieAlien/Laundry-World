// Script skrivet av Sanna Gustafsson

using UnityEngine;
using System.Collections;

public class ConfrontingNicoDialogue : MonoBehaviour
{

    public string[] lines;
    public string[] answerButtons;

    bool displayDialogue = false;
    public static bool activateDialogue = false;
    bool line1 = false;
    bool line2 = false;
    bool line3 = false;
    bool line4 = false;
    bool line5 = false;
    bool hasSpoken = false;
    public PlayerController player;
    public TheMotherOfBlobsDialogue previousQuest;


    private GUIStyle guiStyle = new GUIStyle();


    void Start()
    {
    }

    void Update()
    {
        if (displayDialogue)
        {
            player.canMove = false;
        }

        if (previousQuest.hasDoneQuest || TheFudgeMonster.friends)
        {
            activateDialogue = true;
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height - 100, 350, 500));

        guiStyle.fontSize = 16; // ändra storlek
        guiStyle.normal.textColor = Color.white; // ändra färg

        if (displayDialogue && !hasSpoken && line1)
        {
            GUILayout.Label(lines[0] + "\n" + lines[1], guiStyle);

            if (previousQuest.hasDoneQuest)
            {
                if (GUILayout.Button(answerButtons[1]))
                {
                    line2 = true;
                    line1 = false;
                    previousQuest.activateQuest = false;
                }
            }

            if (TheFudgeMonster.friends)
            {
                if (GUILayout.Button(answerButtons[5]))
                {
                    line1 = false;
                    line4 = true;
                }
            }
            if (GUILayout.Button(answerButtons[0]))
            {
                displayDialogue = false;
                line1 = false;
                player.canMove = true;
            }
        }

        if (line2)
        {
            displayDialogue = true;
            GUILayout.Label(lines[2], guiStyle);

            if (GUILayout.Button(answerButtons[2]))
            {
                line3 = true;
                line2 = false;
            }
        }

        if (line3)
        {
            displayDialogue = true;
            GUILayout.Label(lines[3] + "\n" + lines[4], guiStyle);

            if (GUILayout.Button(answerButtons[3]))
            {
                hasSpoken = true;
                line3 = false;
            }

            if (GUILayout.Button(answerButtons[4]))
            {
                hasSpoken = true;
                line3 = false;
            }
        }

        if (hasSpoken && displayDialogue)
        {
            player.canMove = true;
            GUILayout.Label(lines[5], guiStyle);

            if(Input.GetKeyDown(KeyCode.Return))
            {
                displayDialogue = false;
            }
        }

        if (line4)
        {
            GUILayout.Label(lines[6], guiStyle);

            if (GUILayout.Button(answerButtons[6]))
            {
                line4 = false;
                line5 = true;
            }
        }

        if (line5)
        {
            GUILayout.Label(lines[7], guiStyle);
            player.canMove = true;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                displayDialogue = false;
            }
        }

        GUILayout.EndArea();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && activateDialogue)
        {
             if (!hasSpoken)
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
        }

        if (line5)
        {
            hasSpoken = true;
        }
    }
}
