using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour
{
    
  
  
    //public int gold;
    public int stone = 0;
    public int wood = 0;

    public PlayerPurse Gold;
    public GameObject shopwall;

    Inventory inventory;


    void Start()
    {
        inventory = GameObject.Find("Inventory Panel").GetComponent<Inventory>();

        PlayerPurse.playerGold = 100;
        shopwall.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Shop")
        {
            shopwall.gameObject.SetActive(true);
        }

        
    }

    void OnTriggerExit2D( )
    {
        
        
            shopwall.gameObject.SetActive(false);
        
    }



    void Update()
    {
     
    }

    public void Wood()
    {
        if (PlayerPurse.playerGold >= 10)
        {
            PlayerPurse.playerGold -= 10;
            wood += 5;
        }
    }

    public void Stone()
    {
        if (PlayerPurse.playerGold >= 15)
        {
            PlayerPurse.playerGold -= 15;
            stone += 8;
        }
    }
    public void SellWood()
    {
        if (wood >= 5)
        {
            PlayerPurse.playerGold += 5;
            wood -= 5;
        }
    }

    public void SellStone()
    {
        if (stone >= 8)
        {
            PlayerPurse.playerGold += 8;
            stone -= 8;
        }
    }


    

    
    

	
}
