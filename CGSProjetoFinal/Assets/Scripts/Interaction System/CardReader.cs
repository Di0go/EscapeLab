using UnityEngine;

public class CardReader : MonoBehaviour, IInteractable
{
    public HUD inventory;
    public IInventoryItem neededItem;
    public GameObject neededObj;
    public Door door;

    private void Start()
    {
            neededItem = neededObj.GetComponent<IInventoryItem>();
    }

    public bool Interact(Interactor interactor)
    {
        if (inventory.SelectedItem() == neededItem)
        {
            door.isDoorOpen = true;
            return true;
        }
        return false;
    }
}
