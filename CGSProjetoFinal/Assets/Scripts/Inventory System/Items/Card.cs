using UnityEngine;

public class Card : MonoBehaviour, IInteractable, IInventoryItem
{
    public string Name => "Card";

    public Sprite _Image;

    public Sprite Image => _Image;

    public Inventory inventory;

    public bool Interact(Interactor interactor)
    {
        IInventoryItem item = transform.GetComponent<IInventoryItem>();

        inventory.AddItem(item);
        return true;
    }

    public void OnPickup()
    {
        //gameObject uppon pickup
        gameObject.SetActive(false);
    }
}
