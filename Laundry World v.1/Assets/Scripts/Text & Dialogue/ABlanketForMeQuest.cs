// Script skrivet av Anna Englund

using UnityEngine;
using System.Collections;

public class ABlanketForMeQuest : MonoBehaviour
{
    public ABlanketForMeDialogue dialogue;

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
