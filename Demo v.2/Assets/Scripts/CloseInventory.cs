using UnityEngine;
using System.Collections;

public class CloseInventory : MonoBehaviour
{
    Inventory inventory;
    public AudioSource closeInventorySound;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void OnClick()
    {
        closeInventorySound.Play();

        inventory.closeInventoryButton.SetActive(false);
        inventory.inventoryPanel.SetActive(false);
        inventory.slotPanel.SetActive(false);
        inventory.textPanel.SetActive(false);
        inventory.textText.SetActive(false);
        inventory.backpack.SetActive(true);
    }
}
