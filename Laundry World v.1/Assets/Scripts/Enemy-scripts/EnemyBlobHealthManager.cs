using UnityEngine;
using System.Collections;

public class EnemyBlobHealthManager : MonoBehaviour 
{
    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStats playerStats;

    public int expToGive;

    private TheThreatQuest theThreatQuest;
    //private TheMotherOfBlobsDialogue questDialogue;

    void Start()
    {
        theThreatQuest = FindObjectOfType<TheThreatQuest>();
        playerStats = FindObjectOfType<PlayerStats>();
        //questDialogue = FindObjectOfType<TheMotherOfBlobsDialogue>();

        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if (CurrentHealth <= 0)
        {
            TheThreatQuest.blobsKilled += 1;
            Destroy(gameObject);

            playerStats.AddExperience(expToGive);
        }

        if (TheThreatQuest.blobsKilled == 3)
        {
            theThreatQuest.dialogue.hasDoneQuest = true;
        }

        //if (hasDoneQuest)
        //{
        //    questDialogue.enabled = false;
        //}
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
