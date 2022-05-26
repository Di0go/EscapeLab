using System;
using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private int slots = 4;

    private List<IInventoryItem> playerItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemDropped;

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

            //event trigger - ItemAdded?.Invoke it only invokes the event if the ItemAdded isn't null
            ItemAdded?.Invoke(this, new InventoryEventArgs(item));
        }
    }

    //remove item method
}
