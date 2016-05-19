using UnityEngine;
using System.Collections;

public class TheFudgeMonster : MonoBehaviour {

    public int maxHealth;
    public static int currentHealth;

    public int expToGive;
    private PlayerStats playerStats;
    public TheMotherOfBlobsDialogue nicosQuest;

    public static bool friends = false;

	void Start () 
    {
        playerStats = FindObjectOfType<PlayerStats>();

        currentHealth = maxHealth;
	
	}
	

	void Update () 
    {

        if (currentHealth <= 0)
        {
            playerStats.AddExperience(expToGive);
            nicosQuest.hasDoneQuest = true;
            Destroy(gameObject);
        }
	}

    public static void HurtFM(int damageToGive)
    {
        currentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
