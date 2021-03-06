﻿// Script skrivet av
// Healthregeneration av Sanna Gustafsson

using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;
    private float regenTimer;
    private float regenTimerMax = 5;
    public AudioSource playerDies;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    void Update()
    {        
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        if (playerCurrentHealth < playerMaxHealth)
        {
            regenTimer -= Time.deltaTime;
            if (regenTimer <= 0 && playerCurrentHealth < playerMaxHealth)
            {
                playerCurrentHealth += 1;
                regenTimer = regenTimerMax;
                // spelaren får +5 hälsa baserat på en timer, dock endast om hälsan är lägre än max hälsan
            }

            if (playerCurrentHealth <= 0)
            {
                playerDies.Play();
                playerCurrentHealth = 0;
            }
        }
        else
        {
            regenTimer = regenTimerMax;
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
