using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    private int currentDamage;
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public AudioSource playerHurt;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            currentDamage = damageToGive - playerStats.currentDefence;
            
            if(currentDamage < 0)
            {
                currentDamage = 0;
            }

            playerHurt.Play();
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
        }
    }
}
