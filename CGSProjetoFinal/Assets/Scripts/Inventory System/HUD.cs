using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory inventory;

    void Start()
    {
        //each time an item is added the inventory trigger InventoryScript_ItemAdded
        inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    public void InventoryScript_ItemAdded(object sender, InventoryEventArgs eventItem)
    {
        //find the inventory hud
        Transform InventoryPanel = transform.Find("InventoryPanel");

        //loop trough all the slots in the inventory
        foreach (Transform item in InventoryPanel)
        {
            //get the sprite that is in the slot (Slot -> Border -> Item)
            Image image = item.GetChild(0).GetChild(0).GetComponent<Image>();
            Debug.Log("Found: " + image.enabled);

            //if there is no image (no item or enabled = false)
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
