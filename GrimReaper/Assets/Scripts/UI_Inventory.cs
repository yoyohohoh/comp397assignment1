using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
   private Inventory inventory;
    private Transform image;
    private Transform itemImg;

    private void Awake()
    {
        image = transform.Find("image");
        itemImg = transform.Find("itemImg");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    private void RefreshInventoryItems()
    {
        foreach (Item item in inventory.GetItemList()) {
         
        }
    }
}
