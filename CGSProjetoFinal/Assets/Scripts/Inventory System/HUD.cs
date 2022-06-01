using System;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory inventory;

    void Start()
    {
        //subscribe the methods to the events
        inventory.ItemAdded += _ItemAdded;
        inventory.ItemDropped += _ItemDropped;
    }

    void FixedUpdate()
    {
        inventory.RemoveItem(DropCheck());
    }

    public void _ItemAdded(object sender, InventoryEventArgs eventItem)
    {
        //find the inventory hud
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
                image.sprite = eventItem.Item.Image;

                break;
            }
        }
    }

    //////
    //DROP
    //checks and returns which item was chosen by the player to drop
    private IInventoryItem DropCheck()
    {
        if (inventory.playerItems.Count > 0 && Input.GetKeyDown(KeyCode.Q))
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

                //checks if button is selected
                if (buttonCheck.isSlotSelected)
                {
                    IInventoryItem selectedItem = inventory.playerItems[counter];
                    buttonCheck.isSlotSelected = false;
                    return selectedItem;
                }
                counter++;
            }
        }
        return null;
    }

    //handles the UI part of the drop
    private void _ItemDropped(object sender, InventoryEventArgs eventItem)
    {
        //find the inventory hud
        Transform InventoryPanel = transform.Find("InventoryPanel");

        //loop trough all the slots in the inventory
        foreach (Transform slot in InventoryPanel)
        {
            //get the sprite that is in the slot (Slot -> Border -> Item)
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            if (image.enabled && image.sprite.name == eventItem.Item.Image.name)
            {
                image.sprite = null;

                image.enabled = false;

                break;
            }
        }
    }
}
