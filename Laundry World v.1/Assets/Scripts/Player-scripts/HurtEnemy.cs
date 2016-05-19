using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    private int currentDamage;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;
    public PlayerController player;
    public bool isAttacking;

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            //if (isAttacking)
            //{

            currentDamage = damageToGive + playerStats.currentAttack;

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
            //}
        }

         if (other.gameObject.tag == "FM")
         {
             if (!TheFudgeMonster.friends)
             {
                 currentDamage = damageToGive + playerStats.currentAttack;

                 TheFudgeMonster.HurtFM(damageToGive);
                 Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
                 var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
                 clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
             }
         }
    }
}
