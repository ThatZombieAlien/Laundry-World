using UnityEngine;
using System.Collections;

public class SellShop : MonoBehaviour {

    public int sellstone = 0;
    public int sellwood = 0;

    public PlayerPurse Gold;
    public GameObject shopwall;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SellWood()
    {
        if (PlayerPurse.playerGold >= 10)
        {
            PlayerPurse.playerGold += 10;
            sellwood -= 5;
        }
    }

    public void SellStone()
    {
        if (PlayerPurse.playerGold >= 15 )
        {
            PlayerPurse.playerGold += 15;
            sellstone -= 8;
        }
    }
}
