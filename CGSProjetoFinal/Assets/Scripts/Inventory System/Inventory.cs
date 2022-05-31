using System;
using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private int slots = 4;

    public List<IInventoryItem> playerItems = new List<IInventoryItem>();
    public int listCount;

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemDropped;

    private void Update()
    {
        listCount = playerItems.Count;
    }

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
    public void RemoveItem(IInventoryItem item)
    {
        //check if inventory has items
        if (item != null)
        {
            //event trigger
            ItemDropped?.Invoke(this, new InventoryEventArgs(item));

            //OnDrop from the interface
            item.OnDrop();

            //remove item
            playerItems.Remove(item);
        }
    }
}
