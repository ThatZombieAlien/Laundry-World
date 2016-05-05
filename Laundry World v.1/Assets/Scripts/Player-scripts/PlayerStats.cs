using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExperience;

    public int[] toLevelUp;

    public int[] hpLevels;
    public int[] attackLevels;
    public int[] defenceLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefence;

    private PlayerHealthManager playerHealthManager;

    void Start()
    {
        currentHP = hpLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];

        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
    }

    void Update()
    {
        if(currentExperience >= toLevelUp[currentLevel])
        {
            //currentLevel++;

            LevelUp();
        }
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExperience += experienceToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHP = hpLevels[currentLevel];

        playerHealthManager.playerMaxHealth = currentHP;
        //Om spelaren exempelvis är på level 2, tar man bort hälsan från level 1 (55-50 = 5) och 
        //lägger till det som blir kvar till spelarens nuvarande hälsa
        playerHealthManager.playerCurrentHealth += currentHP - hpLevels[currentLevel - 1];

        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
    }
}
