// Script skrivet av Anna Englund

using UnityEngine;
using System.Collections;

public class BackpackButtonScript : MonoBehaviour
{
    Inventory inventory;
    public AudioSource openInventorySound;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void OnBackPackClick()
    {
        openInventorySound.Play();
        inventory.inventoryPanel.SetActive(true);
        inventory.slotPanel.SetActive(true);
        inventory.textPanel.SetActive(true);
        inventory.textText.SetActive(true);
        inventory.closeInventoryButton.SetActive(true);
        inventory.backpack.SetActive(false);
    }
}