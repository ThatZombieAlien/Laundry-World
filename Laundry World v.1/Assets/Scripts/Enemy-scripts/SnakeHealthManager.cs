using UnityEngine;
using System.Collections;

public class SnakeHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStats playerStats;

    public int expToGive;

    HermitQuest hermitQuest;

    void Start()
    {
        hermitQuest = FindObjectOfType<HermitQuest>();
        playerStats = FindObjectOfType<PlayerStats>();

        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if (CurrentHealth <= 0)
        {
            HermitQuest.snakesKilled += 1;
            Destroy(gameObject);

            playerStats.AddExperience(expToGive);
        }

        if (HermitQuest.snakesKilled == 3)
        {
            print("quest snakes completed");
            hermitQuest.dialogue.hasDoneQuest = true;
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
