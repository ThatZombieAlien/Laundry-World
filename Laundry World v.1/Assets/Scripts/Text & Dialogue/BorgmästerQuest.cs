using UnityEngine;
using System.Collections;

public class BorgmästerQuest : MonoBehaviour
{

    public BorgmästerQuestDialog dialog;
    //public GameObject detergentBorgmästarQuest;
    //private PlayerStats playerStats;

    void Start()
    {
        //dialogue = GameObject.Find("NPC(1)").GetComponent<QuestDialogue>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        // Spelaren plockar upp ett föremål, som sedan förstörs, detta sätter questet till gjort - och det kan nu rapporteras in
        if (dialog.activateQuest)
        {
            //Destroy(detergentBorgmästarQuest);

            if (collider.tag == "Player")
            {
                //Destroy(gameObject);
                dialog.hasDoneQuest = true;

            }
        }

    }
}
