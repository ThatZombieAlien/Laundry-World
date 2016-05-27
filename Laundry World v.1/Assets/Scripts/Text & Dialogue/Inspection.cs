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
    //bool line4 = false;
    //bool line5 = false;
    //bool line6 = false;
    //bool line7 = false;
    //bool line8 = false;
    //bool line9 = false;
    //bool line10 = false;
    //bool line11 = false;
    //bool line12 = false;
    //bool line13 = false;
    //bool line14 = false;
    //bool line15 = false;
    //bool line16 = false;
    //bool line17 = false;
    //bool line18 = false;
    //bool line19 = false;
    //bool line20 = false;



    //
    //	bool displayDialogue = false;
    //	bool activateQuest = false;
    //	bool nextLine = false;
    //	bool firstLine = true;

    //public TextBoxManager textManager;
    //public PlayerController player;
    //public NPCController NPC;

    private GUIStyle GUIStyle = new GUIStyle();


    //void Start()
    //{
    //    blur = FindObjectOfType<Blur>();
    //}

    void Update()
    {
        //if (displayDialogue)
        //{
        //    //textManager.EnableTextBox();
        //    player.canMove = false;
        //    NPC.canMove = false;
        //}
        //else
        //{
        //    //textManager.DisableTextBox();
        //    player.canMove = true;
        //    NPC.canMove = true;
        //}

    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height - 100, 350, 500));

        GUIStyle.fontSize = 16; // ändra storlek
        GUIStyle.normal.textColor = Color.white; // ändra färg
        if (exitDialogue)
        {
            //textManager.DisableTextBox();
        }

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    StartCoroutine(EndBlur());
        //}
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
                //			displayDialogue = true;
                GUILayout.Label(lines[1], GUIStyle);

                if (GUILayout.Button(answerButtons[1]))
                {
                    line2 = true;
                    line1 = false;
                    //						activateQuest = true;

                }
            }

            if (line2)
            {
                //GUILayout.Label(lines[18], guiStyle);
                //GUILayout.Label(lines[19], guiStyle);

                GUILayout.Label(lines[2], GUIStyle);

                if (GUILayout.Button(answerButtons[2]))
                {
                    //line19 = true;

                    line2 = false;
                    displayDialogue = false;
                    exitDialogue = true;
                    Destroy(gameObject); // sätt på sista svaret
                    Debug.Log("exit");
                }

            }

            //				if (line8) 
            //				{
            //					GUILayout.Label (lines [8], guiStyle);
            //
            //					if (GUILayout.Button (answerButtons [6])) 
            //					{
            //						line8 = false;
            //						//						textManager.DisableTextBox ();
            //						displayDialogue = false;
            //						exitDialogue = true;
            //						activateQuest = true;
            //					}
            //				}

            //
            //		if (!activateQuest && nextLine)
            //		{
            //			displayDialogue = true;
            //			GUILayout.Label(lines[2], guiStyle);
            //
            //			if (GUILayout.Button(answerButtons[4]))
            //			{
            //				activateQuest = true;
            //				displayDialogue = true;
            //			}
            //			if (GUILayout.Button(answerButtons[3]))
            //			{
            //				displayDialogue = false;
            //				nextLine= false;
            //				textManager.DisableTextBox();
            //			}
            //		}


        }

        GUILayout.EndArea();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //if (Input.GetKeyDown(KeyCode.E))
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
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            displayDialogue = false;
        }
    }

    //public IEnumerator EndBlur()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //    blur.RemoveBlur();
    //}
}


