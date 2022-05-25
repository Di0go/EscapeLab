using System;
using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private int slots = 4;

    private List<IInventoryItem> playerItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    //add item method
    public void AddItem(IInventoryItem item)
    {
        //if slots are available
        if (playerItems.Count < slots)
        {
            //add the item to the list
            playerItems.Add(item);

            //OnPickup from the interface
            item.OnPickup();

            if (ItemAdded != null)
            {
                //event trigger
                ItemAdded(this, new InventoryEventArgs(item));
            }
        }
    }
}
