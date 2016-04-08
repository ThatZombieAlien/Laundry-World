using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
    GameObject inventoryPanel;
    GameObject slotPanel;
    GameObject textPanel;
    GameObject textText;
    GameObject backpack;

    void Start()
    {
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        textPanel = GameObject.Find("Title Panel");
        textText = textPanel.transform.FindChild("Title").gameObject;
        backpack = GameObject.Find("Backpack");
    }

    public void OnBackPackClick()
    {
        inventoryPanel.SetActive(true);
        slotPanel.SetActive(true);
        textPanel.SetActive(true);
        textText.SetActive(true);

        backpack.SetActive(false);
    }
}
