using System;
using UnityEngine;

//Item interface
public interface IInventoryItem
{
    string Name { get; }
    Sprite Image { get; }

    void OnPickup();
}

//Event class - we use EventArgs because the event does not pass any data, it only serves as an notifier
public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item;
}