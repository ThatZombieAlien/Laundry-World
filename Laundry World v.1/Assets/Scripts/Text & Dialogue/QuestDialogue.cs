using UnityEngine;
using System.Collections;

public class QuestDialogue : MonoBehaviour {


    // OBS: Endast exempel på struktur
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
    public NPCController npc;

    //public Texture texture1;
    //public Texture texture2;


    void Start()
    {
        //textManager = FindObjectOfType<TextBoxManager>();
        //eyeMonster = FindObjectOfType<EyeMonsterController>();
        //player = FindObjectOfType<PlayerMovement>();
        //player.gameObject.transform.position.x = pos.x;
    }

    void Update()
    {
        if (displayDialogue && !activateQuest && !hasDoneQuest)
        {
            textManager.EnableTextBox();
            player.canMove = false;
            npc.canMove = false;
        }
        if (!displayDialogue)
        {
            textManager.DisableTextBox();
            player.canMove = true;
            npc.canMove = true;
        }
        if (displayDialogue && hasDoneQuest)
        {
            textManager.EnableTextBox();
            player.canMove = false;
            npc.canMove = false;
        }

    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height - 80, 350, 500));

        if (displayDialogue && !activateQuest && line1)
        {

            GUILayout.Label(lines[0]);

            if (GUILayout.Button(answerButtons[0]))
            {
                line2 = true;
                displayDialogue = true;
                line1 = false;
            }

            if (GUILayout.Button(answerButtons[3]))
            {
                displayDialogue = false;
                textManager.DisableTextBox();
            }
        }

        if (line2)
        {
            GUILayout.Label(lines[1]);

            if (GUILayout.Button(answerButtons[1]))
            {
                activateQuest = true;
                displayDialogue = false;
                textManager.DisableTextBox();
                line1 = true;
                line2 = false;
            }

            if (GUILayout.Button(answerButtons[3]))
            {
                displayDialogue = false;
                textManager.DisableTextBox();
                line2 = false;
            }
        }

        if (activateQuest && hasDoneQuest && displayDialogue)
        {
            GUILayout.Label(lines[2]);

            if (GUILayout.Button(answerButtons[2]))
            {
                displayDialogue = false;
                line3 = true;
                line1 = false;
                activateQuest = false;
                PlayerPurse.playerGold += reward;
            }

            if (GUILayout.Button(answerButtons[3]))
            {
                displayDialogue = false;
                textManager.DisableTextBox();
            }
        }

        if (line3)
        {
            GUILayout.Label(lines[3]);

            if (GUILayout.Button(answerButtons[0]))
            {
                displayDialogue = false;
                textManager.DisableTextBox();
                line3 = false;
            }
        }

        

        GUILayout.EndArea();

        if (activateQuest)
        {
            //GUI.DrawTexture(new Rect(10, 10, 200, 150), texture1);
            GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.1f, 250, 250)); // "putta ner quests beroende på hur många man har?

            GUILayout.Box("New Quest: Find the book"); // sätt in bools för vilken text som ska visas beroende på vilket quest man är på?

            GUILayout.EndArea();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //if (Input.GetKeyDown(KeyCode.E))
            {
                displayDialogue = true;
                textManager.EnableTextBox();

                if (!activateQuest && !hasDoneQuest)
                {
                    line1 = true;
                }

                if (finishedDialogue)
                {
                    line4 = true;
                }
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
        PlayerPurse.playerGold += reward;

    }
}

