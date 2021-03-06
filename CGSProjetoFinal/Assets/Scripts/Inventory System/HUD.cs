using System;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory inventory;
    public GameObject player;
    private IInventoryItem currentItem;
    private GameObject itemAsObj;

    void OnEnable()
    {
        //subscribe the methods to the events
        inventory.ItemAdded += _ItemAdded;
        //inventory.ItemDropped += _ItemDropped;
        inventory.ItemHeld += _ItemHeld;
    }

    void Update()
    {
        //check what item the player is holding (if none it returns null)
        IInventoryItem selectItem = SelectedItem();

        //currentItem represents the item the player holds, it cannot be null after the first item pickup, hence the null check in the if statment
        //if selectItem is different than the currentItem than De-activate the object in the player's hand :)
        if (currentItem != null && selectItem != currentItem)
        {
            itemAsObj.SetActive(false);
        }
        //same but for when the player selects an empty slot!
        if (selectItem != null)
        {
            inventory.HoldItem(selectItem);
        }
    }

    public void _ItemAdded(object sender, InventoryEventArgs eventData)
    {
        //find the inventory panel
        Transform InventoryPanel = transform.Find("InventoryPanel");

        //loop trough all the slots in the inventory
        foreach (Transform item in InventoryPanel)
        {
            //get the sprite that is in the slot (Slot -> Border -> Item)
            Image image = item.GetChild(0).GetChild(0).GetComponent<Image>();

            //if there is no image (no item in slot)
            if (!image.enabled)
            {
                //enable it 
                image.enabled = true;

                //add the sprite from the picked up item to the slot
                image.sprite = eventData.Item.Image;

                break;
            }
        }
    }

    //checks and returns which item is currently being holded by the player
    public IInventoryItem SelectedItem()
    {
        if (inventory.playerItems.Count > 0)
        {
            //counter
            int counter = 0;

            //find the inventory hud
            Transform InventoryPanel = transform.Find("InventoryPanel");

            //loop trough all the slots in the inventory
            foreach (Transform slot in InventoryPanel)
            {
                //new buttonstate object (Slot -> Border)
                ButtonState buttonCheck = slot.GetChild(0).GetComponent<ButtonState>();

                //checks if button is selected and prevent bad index by only checking for existing items
                if (buttonCheck.isSlotSelected)
                {
                    IInventoryItem selectedItem = inventory.playerItems[counter];
                    return selectedItem;
                }
                //increment to counter each iteration
                counter++;
            }
        }

        return null;
    }

    //item holder event invoker
    private void _ItemHeld(object sender, InventoryEventArgs eventData)
    {
        //create a copy to a new variable
        currentItem = eventData.Item;

        //parse the item to a gameobject
        itemAsObj = (currentItem as MonoBehaviour).gameObject;
    }

}
