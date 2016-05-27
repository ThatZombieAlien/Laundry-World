// Grundkod av Sanna Gustafsson
// Modifierat av 

using UnityEngine;
using System.Collections;

public class HermitQuestDialogue : MonoBehaviour
{
    public string[] lines;
    public string[] answerButtons;

    bool displayDialogue = false;
    public bool activateQuest = false;
    public bool hasDoneQuest = false;
    bool line2 = false;
    bool line1 = true;
    bool line3 = false;
    bool finishedDialogue = false;
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
    }

    void Update()
    {
        if (displayDialogue && !activateQuest && !hasDoneQuest)
        {
            player.canMove = false;
            npc.canMove = false;
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

        if (displayDialogue && !activateQuest && line1)
        {

            GUILayout.Label(lines[0], guiStyle);

            if (GUILayout.Button(answerButtons[0]))
            {
                line2 = true;
                displayDialogue = true;
                line1 = false;
            }

            if (GUILayout.Button(answerButtons[3]))
            {
                displayDialogue = false;
            }
        }

        if (line2 && displayDialogue)
        {
            displayDialogue = true;
            GUILayout.Label(lines[1], guiStyle);

            if (GUILayout.Button(answerButtons[1]))
            {
                activateQuest = true;
                displayDialogue = false;
                line1 = true;
                line2 = false;
            }

            if (GUILayout.Button(answerButtons[3]))
            {
                displayDialogue = false;
                line2 = false;
            }
        }

        if (activateQuest && hasDoneQuest && displayDialogue)
        {
            GUILayout.Label(lines[2], guiStyle);

            if (GUILayout.Button(answerButtons[2]))
            {
                displayDialogue = false;
                line3 = true;
                line1 = false;
                activateQuest = false;

                playerStats.AddExperience(30);
                inventory.AddItem(2);
                inventory.openInventorySound.Play();
                inventory.inventoryPanel.SetActive(true);
                inventory.slotPanel.SetActive(true);
                inventory.textPanel.SetActive(true);
                inventory.textText.SetActive(true);
                inventory.closeInventoryButton.SetActive(true);
            }

            if (GUILayout.Button(answerButtons[3]))
            {
                displayDialogue = false;
            }
        }

        if (line3)
        {
            GUILayout.Label(lines[3], guiStyle);

            if (GUILayout.Button(answerButtons[4]))
            {
                displayDialogue = false; ;
                line3 = false;
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
                    GUILayout.Box("New Quest: Kill the snakes");
                }

                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest completed: Kill the snakes");
                }

                GUILayout.EndArea();
            }
            else
            {
                GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.2f, 250, 250));

                if (!hasDoneQuest)
                {
                    GUILayout.Box("New Quest: Kill the snakes");
                }

                if (hasDoneQuest)
                {
                    GUILayout.Box("Quest completed: Kill the snakes");
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
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            displayDialogue = false;
            player.canMove = true;
            npc.canMove = true;
        }
    }
}

