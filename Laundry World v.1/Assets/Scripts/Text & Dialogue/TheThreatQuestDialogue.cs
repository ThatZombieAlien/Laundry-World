using UnityEngine;
using System.Collections;

public class TheThreatQuestDialogue : MonoBehaviour 
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
    public int reward;
    public TextBoxManager textManager;
    public PlayerController player;
    public NPCController npc;
    private GUIStyle guiStyle = new GUIStyle();

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
        }
        if (!displayDialogue)
        {
            player.canMove = true;
        }
        if (displayDialogue && hasDoneQuest)
        {
            player.canMove = false;
        }

    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height - 100, 350, 600));

        guiStyle.fontSize = 16;
        guiStyle.normal.textColor = Color.white;



        // skriv in dialog osv



        GUILayout.EndArea();

        if (activateQuest)
        {
            GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height * 0.2f, 250, 250));

            GUILayout.Box("New Quest: Kill the blobs");

            GUILayout.EndArea();
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
        PlayerPurse.playerGold += reward;
    }
}
