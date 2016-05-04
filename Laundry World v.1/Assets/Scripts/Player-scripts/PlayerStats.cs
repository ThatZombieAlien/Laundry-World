using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;

    public int[] toLevelUp;

    void Start()
    {

    }

    void Update()
    {
        if(currentExp >= toLevelUp[currentLevel])
        {
            currentLevel++;
        }
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }
}
