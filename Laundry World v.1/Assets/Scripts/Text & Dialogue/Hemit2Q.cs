// Grundkod av Sanna Gustafsson
// Modifierat av Maria Görman

using UnityEngine;
using System.Collections;

public class Hemit2Q : MonoBehaviour
{
    public Hermit2Quest dialogue;
    private Inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Spelaren plockar upp ett föremål, som sedan förstörs, detta sätter questet till gjort - och det kan nu rapporteras in
        if (dialogue.activateQuest)
        {
            if (col.tag == "Player")
            {
                Destroy(gameObject);
                inventory.AddItem(0);
                dialogue.hasDoneQuest = true;
            }
        }
    }
}
