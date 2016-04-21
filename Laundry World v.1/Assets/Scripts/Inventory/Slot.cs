using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public int id;
    private Inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();

        //Checks if the slot is empty, and if we can drop an item in the slot
        if(inventory.items[id].ID == -1)
        {
            inventory.items[droppedItem.slot] = new Item();
            inventory.items[id] = droppedItem.item;
            droppedItem.slot = id;
        }

        //Checks if the slot already has an item
        //If it does, the item will swap positions/slots
        else if(droppedItem.slot != id)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slot = droppedItem.slot;
            item.transform.SetParent(inventory.slots[droppedItem.slot].transform);
            item.transform.position = inventory.slots[droppedItem.slot].transform.position;

            droppedItem.slot = id;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            inventory.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
            inventory.items[id] = droppedItem.item;
        }
    }
}
