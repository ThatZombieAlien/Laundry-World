// Script skrivet av Anna

using UnityEngine;
using System.Collections;

public class PickUpItemController : MonoBehaviour
{
    Inventory inventory;
    GameObject inventoryFullText;
    public AudioSource pickUpSound;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        inventoryFullText = inventory.inventoryPanel.transform.FindChild("Inventory Is Full Text").gameObject;

        inventoryFullText.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUpItem"))
        {
            int itemID = other.transform.gameObject.GetComponent<PickUpItem>().itemID;
            bool addedItem = inventory.AddItem(itemID);
            pickUpSound.Play();

            //Om ett item hamnar i inventoryt förstörs objektet
            if (addedItem)
            {
                Destroy(other.transform.gameObject);
            }
            else
            {
                inventoryFullText.SetActive(true);
                Debug.Log("Inventory is full");
            }
        }
    }
}
