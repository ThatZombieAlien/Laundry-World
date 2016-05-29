// Script-mall skrivet av David Zerate Abreu
// Modifierat av Anna Englund
using UnityEngine;
using System.Collections;

public class SnakeHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private PlayerStats playerStats;
    public int expToGive;
    private HermitQuestDialogue dialogue;
    public static int snakesKilled = 0;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        dialogue = FindObjectOfType<HermitQuestDialogue>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            snakesKilled += 1;
            Destroy(gameObject);

            playerStats.AddExperience(expToGive);
        }

        if (snakesKilled == 3)
        {
            print("quest snakes completed");
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
