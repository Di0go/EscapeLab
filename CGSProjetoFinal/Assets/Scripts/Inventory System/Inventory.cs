using System;
using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private int slots = 3;

    public List<IInventoryItem> playerItems = new List<IInventoryItem>();
    public int listCount;

    public event EventHandler<InventoryEventArgs> ItemAdded;
    //public event EventHandler<InventoryEventArgs> ItemDropped;
    public event EventHandler<InventoryEventArgs> ItemHeld;

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

    //use item method
    public void HoldItem(IInventoryItem item)
    {
            //OnUse method (specific to each object)
            item.OnHold();

            //event trigger
            ItemHeld?.Invoke(this, new InventoryEventArgs(item));
    }
}
