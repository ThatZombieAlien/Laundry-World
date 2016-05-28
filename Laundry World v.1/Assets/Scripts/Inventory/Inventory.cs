// Script skrivet av Anna Englund

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPanel;
    public GameObject textPanel;
    public GameObject textText;
    public GameObject backpack;
    public GameObject closeInventoryButton;
    ItemDatabase database;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    public AudioSource openInventorySound;

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();

        slotAmount = 9;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        backpack = GameObject.Find("Backpack");
        closeInventoryButton = inventoryPanel.transform.FindChild("Close Inventory Button").gameObject;
        textPanel = GameObject.Find("Title Panel");
        textText = textPanel.transform.FindChild("Title").gameObject;

        inventoryPanel.SetActive(false);
        slotPanel.SetActive(false);
        textPanel.SetActive(false);
        textText.SetActive(false);

        //Loops through "slotAmount"
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            openInventorySound.Play();
            inventoryPanel.SetActive(true);
            slotPanel.SetActive(true);
            textPanel.SetActive(true);
            textText.SetActive(true);
            closeInventoryButton.SetActive(true);
            backpack.SetActive(false);
        }
    }

    public bool AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);

        //Checks if we can stack the item and if the item is already in the inventory
        if (itemToAdd.Stackable && (ItemCheck(itemToAdd) >= 0))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    return true;
                }
            }
        }

        //If the item is not in the inventory, it will be assigned to an empty slot
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                //Checks if the slot is empty
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObject = Instantiate(inventoryItem);
                    itemObject.GetComponent<ItemData>().item = itemToAdd;
                    itemObject.GetComponent<ItemData>().amount = 1;
                    itemObject.GetComponent<ItemData>().slot = i;
                    itemObject.transform.SetParent(slots[i].transform);
                    itemObject.transform.position = slots[i].transform.position;
                    itemObject.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObject.name = itemToAdd.Title;
                    return true;
                }
            }

            return false;
        }

        return false;
    }

    private int RemoveAtPos(int pos, Item itemToRemove)
    {
        //Checks if the value that was returned represents a valid position
        if (pos != -1)
        {
            //Checks if the item that we're removing is stackable
            if (items[pos].Stackable)
            {
                ItemData data = slots[pos].transform.GetComponentInChildren<ItemData>();
                data.amount--;
                //Check whether or not the item still has anything left; if not we need to remove it from the item list
                if (data.amount == 0)
                {
                    items[pos] = new Item();
                    Transform t = slots[pos].transform.GetChild(0);
                    Destroy(t.gameObject);
                    return 0;
                }
                //Checs if the amount of the object that's left is equal to 1; then we can change it to "" so that nothing is displayed
                else
                {
                    if (data.amount == 1)
                        data.transform.GetComponentInChildren<Text>().text = "";
                    else
                        data.transform.GetComponentInChildren<Text>().text = data.amount.ToString();
                    return data.amount;
                }
            }

            //Removes unstackable items
            else
            {
                items[pos] = new Item();
                Transform t = slots[pos].transform.GetChild(0);
                Destroy(t.gameObject);
                return 0;
            }
        }
        return -1;
    }

    public int RemoveItem(int id)
    {
        Item itemToRemove = database.FetchItemByID(id);
        int pos = ItemCheck(itemToRemove);
        return (RemoveAtPos(pos, itemToRemove));
    }

    public int RemoveUniqueItem(int uniqueId, int itemId)
    {
        Item itemToRemove = database.FetchItemByID(itemId);
        int pos = UniqueItemCheck(uniqueId);
        return (RemoveAtPos(pos, itemToRemove));
    }

    int ItemCheck(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
                return i;
        }
        return -1;
    }

    int UniqueItemCheck(int id)
    {
        GameObject invSlots = GameObject.Find("Slot Panel");
        foreach (Transform child in invSlots.transform)
        {
            try
            {
                if (child.transform.GetChild(0).GetInstanceID() == id)
                    return child.GetComponent<Slot>().id;
            }
            catch
            { }
        }
        return -1;
    }
}