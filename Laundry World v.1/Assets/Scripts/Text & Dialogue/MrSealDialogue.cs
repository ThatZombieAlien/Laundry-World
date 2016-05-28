// Grundkod av Sanna Gustafsson
// Modifierat av Nicolina Christiansson

using UnityEngine;
using System.Collections;

public class MrSealDialogue : MonoBehaviour
{

    public string[] lines;
    public string[] answerButtons;

    bool displayDialogue = false;
    public bool activateQuest = false;
    public bool hasDoneQuest = false;
    bool line1 = true;
    bool line2 = false;
    bool line3 = false;
    bool line4 = false;
    public bool line5 = false;
    bool finishedDialogue = false;
    public int reward;
    public TextBoxManager textManager;
    public PlayerController player;
    public NPCController npc;
    private GUIStyle guiStyle = new GUIStyle();

    private PlayerStats playerStats;
    private Inventory inventory;


    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        inventory.backpack.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            inventory.backpack.SetActive(true);
            player.canMove = true;
        }

        if (displayDialogue && !activateQuest && line1)
        {

            GUILayout.Label(lines[0], guiStyle);   //Replik 1

            if (GUILayout.Button(answerButtons[0]))
            {
                displayDialogue = true;
                line2 = true;
                line1 = false;
            }
        }

        if (line2 && displayDialogue)   //Replik 2
        {
            displayDialogue = true;
            GUILayout.Label(lines[1], guiStyle);

            if (GUILayout.Button(answerButtons[1]))
            {
                displayDialogue = true;
                line3 = true;
                line2 = false;
            }

            if(GUILayout.Button(answerButtons[2]))
            {
                displayDialogue = true;
                line4 = true;
                line2 = false;
            }
        }

        if (line3 && displayDialogue) //Replik 3 
        {
            displayDialogue = true;
            GUILayout.Label(lines[2], guiStyle);

            if (GUILayout.Button(answerButtons[2]))
            {
                displayDialogue = true;
                line4 = true;
                line3 = false;
            }
        }

        if (line4 && displayDialogue) //Replik 4 
        {
            displayDialogue = true;
            GUILayout.Label(lines[3], guiStyle);

            if (GUILayout.Button(answerButtons[3]))
            {
                displayDialogue = true;
                line5 = true;
                line4 = false;
            }
        }

        if (line5 && displayDialogue) //Replik 5
        {
            displayDialogue = true;
            GUILayout.Label(lines[4], guiStyle);

            if (GUILayout.Button(answerButtons[4]))
            {
                displayDialogue = false;
                line5 = false;
                Destroy(gameObject); // sätt på sista svaret
                inventory.backpack.SetActive(true);
                inventory.AddItem(11);
                finishedDialogue = true;
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
                    GUILayout.Box("New Quest: Find Furpig");
                }
                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest Completed: Furpig found!");
                }
                GUILayout.EndArea();
            }
            else
            {
                GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.2f, 250, 250));

                if (!hasDoneQuest)
                {
                    GUILayout.Box("New Quest: Find Furpig");
                }
                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest Completed: Furpig found!");
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
