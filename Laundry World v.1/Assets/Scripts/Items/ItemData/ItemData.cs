using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public int amount;
    public int slot;

    private Inventory inventory;
    CharacterPanel characterPanel;
    private Tooltip tooltip;
    private Vector2 offset;

    void Start()
    {
        characterPanel = GameObject.Find("Character Panel").GetComponent<CharacterPanel>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip = inventory.GetComponent<Tooltip>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //If there is a item to drag in the inventory
        if (item != null)
        {
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - offset;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //If there is a item to drag, we make sure the item's position is equal to the mouse position each frame
        if (item != null)
        {
            this.transform.position = eventData.position - offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(inventory.slots[slot].transform);
        this.transform.position = inventory.slots[slot].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //The item's position snaps back to its original position when we stop dragging the item
        if (item != null)
        {
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        }

        if (eventData.pointerId == -2)
        {
            if (item.Type == "Hand" || item.Type == "MainHand")
            {
                int uniqueId = GameObject.Find("Slot Panel").transform.GetChild(slot).transform.GetChild(0).GetInstanceID();

                characterPanel.EquipItem(item, uniqueId);
                inventory.RemoveItem(item.ID);
                tooltip.Deactivate();
            }
        }

        //if (eventData.pointerId == -2)
        //{
        //    if (item.Consumable)
        //    {
        //        switch (item.ID)
        //        {
        //            case 0:
        //                Do something when item.ID == 0
        //                break;
        //            case 1:
        //                Do something when item.ID == 1
        //                break;
        //        }

        //        inventory.RemoveItem(item.ID);
        //        tooltip.Deactivate();
        //    }
        //}
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }
}
