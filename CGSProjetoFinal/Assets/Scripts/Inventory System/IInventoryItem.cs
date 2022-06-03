using System;
using UnityEngine;

//Item interface
public interface IInventoryItem
{
    string Name { get; }
    Sprite Image { get; }
    GameObject player { get; set; }

    void OnPickup();
    //void OnDrop();
    void OnHold();
}

//This class allows us to pass the item as an argument when the event is triggered
public class InventoryEventArgs : EventArgs
{
    public IInventoryItem Item;

    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }
}