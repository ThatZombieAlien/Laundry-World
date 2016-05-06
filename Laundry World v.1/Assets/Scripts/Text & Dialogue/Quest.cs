using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour
{
    public QuestDialogue dialogue;
    //private PlayerStats playerStats;

    void Start()
    {
        //dialogue = GameObject.Find("NPC(1)").GetComponent<QuestDialogue>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        // Spelaren plockar upp ett föremål, som sedan förstörs, detta sätter questet till gjort - och det kan nu rapporteras in
        if (dialogue.activateQuest)
        {
            if (col.tag == "Player")
            {
                Destroy(gameObject);
                dialogue.hasDoneQuest = true;
            }
        }

    }
}
