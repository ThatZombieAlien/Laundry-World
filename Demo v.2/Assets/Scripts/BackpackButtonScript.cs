using UnityEngine;
using System.Collections;

public class BackpackButtonScript : MonoBehaviour
{
    Inventory inventory;

    void Start()
    {
        //inventoryPanel = GameObject.Find("Inventory Panel");
        //slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        //textPanel = GameObject.Find("Title Panel");
        //textText = textPanel.transform.FindChild("Title").gameObject;
        //backpack = GameObject.Find("Backpack");

        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        inventory.inventoryPanel = GameObject.Find("Inventory Panel");
        inventory.slotPanel = inventory.inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        inventory.textPanel = GameObject.Find("Title Panel");
        inventory.textText = inventory.textPanel.transform.FindChild("Title").gameObject;
        inventory.backpack = GameObject.Find("Backpack");
    }

    public void OnBackPackClick()
    {
        inventory.inventoryPanel.SetActive(true);
        inventory.slotPanel.SetActive(true);
        inventory.textPanel.SetActive(true);
        inventory.textText.SetActive(true);

        inventory.backpack.SetActive(false);
    }
}