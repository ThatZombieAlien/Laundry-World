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

    public TheFudgeMonster fudgeMonster;
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Snake")
        {
            
            //if (isAttacking)
            //{

            currentDamage = damageToGive + playerStats.currentAttack;

            other.gameObject.GetComponent<SnakeHealthManager>().HurtEnemy(currentDamage);
            //other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
            //}
        }

        if (other.gameObject.tag == "Blob")
        {
            currentDamage = damageToGive + playerStats.currentAttack;

            other.gameObject.GetComponent<EnemyBlobHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }

         if (other.gameObject.tag == "FM")
         {
             if (!TheFudgeMonster.friends)
             {
                 if (TheFudgeMonster.canHurt)
                 {
                     currentDamage = damageToGive + playerStats.currentAttack;

                     fudgeMonster.HurtFM(currentDamage);
                     Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
                     var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
                     clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
                 }
             }
         }
    }
}
