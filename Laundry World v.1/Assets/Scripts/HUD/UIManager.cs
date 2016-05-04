using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text hpText;
    public PlayerHealthManager playerHealth;

    PlayerStats playerStats;
    public Text levelText;
    public Text expText;

    private static bool UIexists;

    void Start()
    {
        if (!UIexists)
        {
            UIexists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        hpText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        levelText.text = "Level: " + playerStats.currentLevel;
        expText.text = "XP: " + playerStats.currentExp;
    }
}
