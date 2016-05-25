using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour
{
    //public int gold;
    public int stone = 0;
    public int yarn = 0;

    public PlayerPurse Gold;
    public GameObject shopwall;

    private Inventory inventory;
    private ABlanketForMeDialogue dialogue;
    public static bool hasBought;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
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

    void OnTriggerExit2D()
    {
        shopwall.gameObject.SetActive(false);
    }

    public void Yarn()
    {
        if (PlayerPurse.playerGold >= 10)
        {
            PlayerPurse.playerGold -= 10;
            yarn += 5;

            inventory.AddItem(1);
        }
    }

    public void Scissor()
    {
        if (PlayerPurse.playerGold >= 15)
        {
            PlayerPurse.playerGold -= 15;
            stone += 8;

            inventory.AddItem(3);
            hasBought = true;
        }
    }
    public void SellYarn()
    {
        if (yarn >= 5)
        {
            PlayerPurse.playerGold += 10;
            yarn -= 5;

            inventory.RemoveItem(1);
        }
    }

    public void SellScissor()
    {
        if (stone >= 8)
        {
            PlayerPurse.playerGold += 15;
            stone -= 8;

            inventory.RemoveItem(3);
        }
    }
}
