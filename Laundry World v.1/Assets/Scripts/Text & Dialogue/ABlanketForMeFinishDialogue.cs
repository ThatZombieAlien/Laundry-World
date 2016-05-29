// Script skrivet av Sanna Gustafsson

using UnityEngine;
using System.Collections;

public class ABlanketForMeFinishDialogue : MonoBehaviour {

    public string[] lines;
    public string[] answerButtons;

    bool displayDialogue = false;
    bool haveSpoken = false;
    bool line1 = false;
    bool line2 = false;
    bool line3 = false;
    bool line4 = false;
    bool line5 = false;
    public PlayerController player;
    public ABlanketForMeDialogue previousQuest;

    private GUIStyle GUIStyle = new GUIStyle();

    private Inventory inventory;


    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        if (!previousQuest.hasDoneQuest)
        {
            this.enabled = false;
        }
    }

    void Update()
    {
        if (displayDialogue)
        {
            player.canMove = false;
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height - 100, 350, 500));

        GUIStyle.fontSize = 16; // ändra storlek
        GUIStyle.normal.textColor = Color.white; // ändra färg

        if (displayDialogue && line1)
        {
            GUILayout.Label(lines[0], GUIStyle);

            if (GUILayout.Button(answerButtons[0]))
            {
                line1 = false;
                line2 = true;
            }
        }

        if (line2)
        {
            GUILayout.Label(lines[1], GUIStyle);

            if (GUILayout.Button(answerButtons[1]))
            {
                line2 = false;
                line3 = true;
            }
        }

        if (line3)
        {
            GUILayout.Label(lines[2], GUIStyle);

            if (GUILayout.Button(answerButtons[2]))
            {
                line3 = false;
                line4 = true;
            }
        }

        if (line4)
        {
            GUILayout.Label(lines[3] + "\n" + lines[4], GUIStyle);

            if (GUILayout.Button(answerButtons[3]))
            {
                line4 = false;
                line5 = true;

                inventory.AddItem(4);
                inventory.openInventorySound.Play();
                inventory.inventoryPanel.SetActive(true);
                inventory.slotPanel.SetActive(true);
                inventory.textPanel.SetActive(true);
                inventory.textText.SetActive(true);
                inventory.closeInventoryButton.SetActive(true);
            }
        }

        if (line5)
        {
            GUILayout.Label(lines[5], GUIStyle);

            if (GUILayout.Button(answerButtons[4]))
            {
                displayDialogue = false;
                line5 = false;
                haveSpoken = true;
                previousQuest.activateQuest = false;
                player.canMove = true;
            }
        }

        if (haveSpoken && displayDialogue)
        {
            player.canMove = true;
            GUILayout.Label(lines[4], GUIStyle);

            if (GUILayout.Button(answerButtons[5]))
            {
                displayDialogue = false;
            }
        }

        GUILayout.EndArea();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {          
            if (!haveSpoken)
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
            line2 = false;
            line3 = false;
            line4 = false;
            line5 = false;
        }
    }
}

