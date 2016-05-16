using UnityEngine;
using System.Collections;

public class HermitQuest : MonoBehaviour
{
    public HermitQuestDialogue dialogue;
    public EnemyHealthManager enemyHealthManager;

    public static int snakesKilled = 0;

    void Update()
    {
        //ska egentligen vara == 3, men då avslutas inte questen?
        if(snakesKilled == 2)
        {
            dialogue.hasDoneQuest = true;
        }
    }
}
