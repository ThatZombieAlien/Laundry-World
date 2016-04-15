using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class PickUpItemController : MonoBehaviour
{
    Inventory inventory;
    GameObject fullInventoryText;
    public AudioSource pickUpSound;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        fullInventoryText = inventory.inventoryPanel.transform.FindChild("InventoryIsFullText").gameObject;

        fullInventoryText.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUpItem"))
        {
            int itemID = other.transform.gameObject.GetComponent<PickUpItem>().itemID;
            bool addedItem = inventory.AddItem(itemID);
            pickUpSound.Play();

            if (addedItem)
            {
                Destroy(other.transform.gameObject);
            }
            else
            {
                fullInventoryText.SetActive(true);
                Debug.Log("Inventory is full");
            }
        }
    }
}
