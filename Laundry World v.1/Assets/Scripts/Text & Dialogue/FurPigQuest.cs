// Grundkod av Sanna Gustafsson
// Modifierat av Nicolina Christiansson

using UnityEngine;
using System.Collections;

public class FurPigQuest : MonoBehaviour
{
    public FurPigDialogue dialogue;

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
