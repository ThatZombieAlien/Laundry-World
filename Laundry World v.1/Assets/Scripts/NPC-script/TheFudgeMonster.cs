// Script skrivet av Sanna Gustafsson

using UnityEngine;
using System.Collections;

public class TheFudgeMonster : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    public int expToGive;
    private PlayerStats playerStats;
    public TheMotherOfBlobsDialogue nicosQuest;
    public AudioSource playerHurt;

    public static bool friends = false;
    public static bool canHurt = false;

    public int damageToGive;
    private int currentDamage;

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (canHurt)
        {
            if (other.gameObject.name == "Player")
            {
                currentDamage = damageToGive - playerStats.currentDefence;

                if (currentDamage < 0)
                {
                    currentDamage = 0;
                }

                playerHurt.Play();
                other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
            }
        }
    }
}
