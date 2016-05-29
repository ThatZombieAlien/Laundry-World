// Grundkod av Sanna Gustafsson
// Modifierat av Maria Görman

using UnityEngine;
using System.Collections;

public class Inspection : MonoBehaviour
{
    public string[] lines;
    public string[] answerButtons;

    bool displayDialogue = false;
    bool activateQuest = false;
    bool exitDialogue = false;
    bool line0 = true;
    bool line1 = false;
    bool line2 = false;
    bool line3 = false;

    private GUIStyle GUIStyle = new GUIStyle();

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height - 100, 350, 500));

        GUIStyle.fontSize = 16; // ändra storlek
        GUIStyle.normal.textColor = Color.white; // ändra färg

        if (displayDialogue)
        {
            if (line0)
            {
                GUILayout.Label(lines[0], GUIStyle);

                if (GUILayout.Button(answerButtons[0]))
                {
                    line1 = true;
                    line0 = false;
                }
            }

            if (line1)
            {
                GUILayout.Label(lines[1], GUIStyle);

                if (GUILayout.Button(answerButtons[1]))
                {
                    line2 = true;
                    line1 = false;
                }
            }

            if (line2)
            {
                GUILayout.Label(lines[2], GUIStyle);

                if (GUILayout.Button(answerButtons[2]))
                {
                    line2 = false;
                    displayDialogue = false;
                    exitDialogue = true;
                    Destroy(gameObject); // sätt på sista svaret
                    Debug.Log("exit");
                }
            }
        }

        GUILayout.EndArea();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!activateQuest)
            {
                line0 = true;
            }
            displayDialogue = true;
            exitDialogue = false;
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
}


