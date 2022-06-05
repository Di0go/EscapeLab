using UnityEngine;

public class Bomb : MonoBehaviour, IInteractable, IInventoryItem
{
    public string Name => "Bomb";

    public Sprite _Image;

    public Sprite Image => _Image;

    public GameObject player { get; set; }

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

        //change items scale
        gameObject.transform.localScale = gameObject.transform.localScale * 0.4f;
    }

    public void OnHold()
    {
        Debug.Log("On Hold!");
    }
}
