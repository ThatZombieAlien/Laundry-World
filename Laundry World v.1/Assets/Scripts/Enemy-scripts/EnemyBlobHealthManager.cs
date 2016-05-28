// Script-mall skrivet av David Zerate Abreu
// Modifierat av Anna Englund

using UnityEngine;
using System.Collections;

public class EnemyBlobHealthManager : MonoBehaviour 
{
    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStats playerStats;

    public int expToGive;

    private TheThreatQuestDialogue dialogue;

    public static int blobsKilled = 0;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        dialogue = FindObjectOfType<TheThreatQuestDialogue>();

        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if (CurrentHealth <= 0)
        {
            blobsKilled += 1;
            Destroy(gameObject);

            playerStats.AddExperience(expToGive);
        }

        if (blobsKilled == 3)
        {
            dialogue.hasDoneQuest = true;
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
