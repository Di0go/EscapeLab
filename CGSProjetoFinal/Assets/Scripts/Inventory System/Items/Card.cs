using UnityEngine;

public class Card : MonoBehaviour, IInteractable, IInventoryItem
{
    public string Name => "Card";

    public Sprite _Image;

    public Sprite Image => _Image;

    public GameObject player { get; set;  }

    //reference to the inventory
    [SerializeField] private Inventory inventory;

    public bool Interact(Interactor interactor)
    {
        //fetch the IIventoryItem component and create an item object from the object
        IInventoryItem item = transform.GetComponent<IInventoryItem>();

        //creates a reference to the player for later usage
        player = interactor.gameObject;

        //add it to the list
        inventory.AddItem(item);

        return true;
    }

    //TO-DO: cute scale animation OnPickup and OnDrop
    public void OnPickup()
    {
        //gameObject uppon pickup
        gameObject.SetActive(false);

        //change layer to non interactable
        gameObject.layer = default;
    }

    /*
    public void OnDrop()
    {
        //change the objects position to the front of the player
        gameObject.transform.position = player.transform.position + Vector3.forward * 2;

        //sets the object to true if it's false
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }
    */

    public void OnHold()
    {
        gameObject.SetActive(true);

        //make the item a parent of the hand of the player
        gameObject.transform.parent = player.transform.GetChild(1).transform;

        //make the position of the item the same as the position of the hand
        gameObject.transform.position = player.transform.GetChild(1).position;
    }
}
