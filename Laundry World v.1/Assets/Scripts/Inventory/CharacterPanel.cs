using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    Inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void EquipItem(Item newEquip, int uniqueId)
    {
        foreach (Transform child in transform)
        {
            try
            {
                if (child.GetComponent<EquipmentSlot>().equipmentType == newEquip.Type)
                {
                    EquipmentSlot equip = child.GetComponent<EquipmentSlot>();
                    child.GetChild(0).GetComponent<Image>().sprite = newEquip.Sprite;
                    child.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 1);
                    //Checks if an item isn't already equipped
                    if (equip.equippedItem.ID == -1)
                    {
                        inventory.RemoveUniqueItem(uniqueId, newEquip.ID);
                        equip.equippedItem = newEquip;
                    }
                    else
                    {
                        //Remove the equipping item from the inventory
                        inventory.RemoveUniqueItem(uniqueId, newEquip.ID);
                        //Assign the current weapon to a holding variable
                        Item holder = equip.equippedItem;
                        //Adds the current item to the inventory
                        if (inventory.AddItem(holder.ID) != null)
                        {
                            equip.equippedItem = newEquip;
                        }
                        else
                        {
                            inventory.AddItem(newEquip.ID);
                        }
                    }
                }
            }
            catch { }
        }
    }
}
