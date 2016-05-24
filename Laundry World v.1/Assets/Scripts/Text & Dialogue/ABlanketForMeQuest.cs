using UnityEngine;
using System.Collections;

public class ABlanketForMeQuest : MonoBehaviour
{
    //private Inventory inventory;
    public ABlanketForMeDialogue dialogue;

    void Start()
    {
        //inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    void Update()
    {
        if (dialogue.activateQuest)
        {
            if (Shop.hasBought)
            {
                dialogue.hasDoneQuest = true;
            }
        }
    }
}
