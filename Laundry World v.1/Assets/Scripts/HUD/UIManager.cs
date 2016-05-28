// Script skrivet av Anna Englund

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    PlayerStats playerStats;
    public Text levelText;
    public Text experienceText;

    private static bool UIexists;

    void Start()
    {
        //Ser till att UI:en inte dubbleras när karaktären går till nya områden eller när en ny scen laddas
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
        HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        levelText.text = "Level: " + playerStats.currentLevel;
        experienceText.text = "XP: " + playerStats.currentExperience;
    }
}
