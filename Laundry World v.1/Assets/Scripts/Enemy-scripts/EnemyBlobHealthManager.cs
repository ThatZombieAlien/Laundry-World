using UnityEngine;
using System.Collections;

public class EnemyBlobHealthManager : MonoBehaviour 
{
    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStats playerStats;

    public int expToGive;

    private TheThreatQuest theThreatQuest;

    void Start()
    {
        theThreatQuest = FindObjectOfType<TheThreatQuest>();
        playerStats = FindObjectOfType<PlayerStats>();

        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if (CurrentHealth <= 0)
        {
            TheThreatQuest.blobsKilled += 1;
            Destroy(gameObject);
            print(TheThreatQuest.blobsKilled);

            playerStats.AddExperience(expToGive);
        }

        if (TheThreatQuest.blobsKilled == 3)
        {
            print("quest blobs completed");
            theThreatQuest.dialogue.hasDoneQuest = true;
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
