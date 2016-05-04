using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStats playerStats;

    public int expToGive;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();

        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy (gameObject);

            playerStats.AddExperience(expToGive);
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
