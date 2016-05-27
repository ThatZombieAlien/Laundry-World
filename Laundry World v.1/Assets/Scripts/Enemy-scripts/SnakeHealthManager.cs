using UnityEngine;
using System.Collections;

public class SnakeHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStats playerStats;

    public int expToGive;

    private HermitQuestDialogue dialogue;

    public static int snakesKilled = 0;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        dialogue = FindObjectOfType<HermitQuestDialogue>();

        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if (CurrentHealth <= 0)
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
        CurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
