// Script skrivet av Sanna Gustafsson

using UnityEngine;
using System.Collections;

public class TheFudgeMonster : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    public int expToGive;
    private PlayerStats playerStats;
    public TheMotherOfBlobsDialogue nicosQuest;

    public static bool friends = false;
    public static bool canHurt = false;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        if (friends)
        {
            canHurt = false;
        }

        if (currentHealth <= 0)
        {
            playerStats.AddExperience(expToGive);
            nicosQuest.hasDoneQuest = true;
            Destroy(gameObject);
        }
    }

    public void HurtFM(int damageToGive)
    {
        currentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
