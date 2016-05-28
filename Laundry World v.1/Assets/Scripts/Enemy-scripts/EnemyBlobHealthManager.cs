// Script-mall skrivet av David Zerate Abreu
// Modifierat av Anna Englund

using UnityEngine;
using System.Collections;

public class EnemyBlobHealthManager : MonoBehaviour 
{
    public int maxHealth;
    public int currentHealth;

    private PlayerStats playerStats;

    public int expToGive;

    private TheThreatQuestDialogue dialogue;

    public static int blobsKilled = 0;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        dialogue = FindObjectOfType<TheThreatQuestDialogue>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
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
        currentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
