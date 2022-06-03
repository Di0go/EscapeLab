using UnityEngine;

public class Empty : MonoBehaviour, IInventoryItem
{
    public string Name => "Empty";

    public Sprite Image { get; set; }

    public GameObject player { get; set; }

    //reference to the inventory
    [SerializeField] private Inventory inventory;

    public bool Interact(Interactor interactor)
    {
        return true;
    }

    public void OnPickup()
    {
    }

    public void OnHold()
    {
        Debug.Log("Empty!");
    }
}
