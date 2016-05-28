// Grundkod av Sanna Gustafsson
// Modifierat av Nicolina Christiansson

using UnityEngine;
using System.Collections;

public class BorgmästerQuest : MonoBehaviour
{
    public BorgmästerQuestDialog dialog;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Spelaren plockar upp ett föremål, som sedan förstörs, detta sätter questet till gjort - och det kan nu rapporteras in
        if (dialog.activateQuest)
        {
            if (collider.tag == "Player")
            {
                dialog.hasDoneQuest = true;
            }
        }
    }
}
