using UnityEngine;

public class Screwdriver : MonoBehaviour, IInteractable, IInventoryItem
{
    public string Name => "Screwdriver";

    public Sprite _Image;

    public Sprite Image => _Image;

    public RaycastHit[] hits;

    public GameObject player { get; set; }

    //reference to the inventory
    [SerializeField] private Inventory inventory;

    void Update()
    {
        transform.localRotation = Quaternion.identity;
    }

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

        gameObject.transform.localScale = gameObject.transform.localScale * 0.8f;
    }

    public void OnHold()
    {
        gameObject.SetActive(true);

        //make the item a parent of the hand of the player
        gameObject.transform.parent = player.transform.GetChild(1).transform;

        //make the position of the item the same as the position of the hand
        gameObject.transform.position = player.transform.GetChild(1).position;
    }
}
