using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

    public QuestDialogue dialogue;

    void Start()
    {
        //dialogue = GameObject.Find("NPC(1)").GetComponent<QuestDialogue>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {

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
