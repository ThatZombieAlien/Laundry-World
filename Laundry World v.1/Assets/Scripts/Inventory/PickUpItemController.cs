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
                inventoryFullText.SetActive(true);
                Debug.Log("Inventory is full");
            }
        }
    }
}
