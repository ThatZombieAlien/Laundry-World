using UnityEngine;
using System.Collections;

public class PickUpItemController : MonoBehaviour
{
    Inventory inventory;
    public AudioSource pickUpSound;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    inventory.RemoveItem(4);
        //}

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    inventory.RemoveItem(2);
        //}
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
                Debug.Log("Inventory is full");
            }
        }
    }
}
