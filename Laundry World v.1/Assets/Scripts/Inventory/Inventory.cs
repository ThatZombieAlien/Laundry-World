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

    public bool RemoveItem(int id)
    {
        Item itemToRemove = database.FetchItemByID(id);
        int pos = ItemCheck(itemToRemove);

        if (pos != -1)
        {
            if (items[pos].Stackable)
            {
                ItemData data = slots[pos].transform.GetComponentInChildren<ItemData>();
                data.amount--;
                if (data.amount == 0)
                {
                    items[pos] = new Item();
                    Transform t = slots[pos].transform.GetChild(0);
                    Destroy(t.gameObject);

                }
                else
                {
                    if (data.amount == 1)
                        data.transform.GetComponentInChildren<Text>().text = "";
                    else
                        data.transform.GetComponentInChildren<Text>().text = data.amount.ToString();
                }
                return true;
            }
            else
            {
                items[pos] = new Item();
                Transform t = slots[pos].transform.GetChild(0);
                Destroy(t.gameObject);
                return true;
            }
        }

        return false;
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
}