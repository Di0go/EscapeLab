using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory inventory;

    void Start()
    {
        //subscribe the Inventory_ItemAdded method to the ItemAdded event, when the event is triggered the method will execute
        inventory.ItemAdded += Inventory_ItemAdded;
    }

    public void Inventory_ItemAdded(object sender, InventoryEventArgs eventItem)
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
}
