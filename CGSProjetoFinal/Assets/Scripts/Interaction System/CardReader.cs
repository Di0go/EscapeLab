using UnityEngine;

public class CardReader : MonoBehaviour, IInteractable
{
    public HUD inventory;
    public IInventoryItem neededItem;
    public GameObject neededObj;
    public Door door;
    public AudioSource source;
    public AudioClip clip;

    private void Start()
    {
            neededItem = neededObj.GetComponent<IInventoryItem>();
            source = GetComponent<AudioSource>();
    }

    public bool Interact(Interactor interactor)
    {
        if (inventory.SelectedItem() == neededItem)
        {
            door.isDoorOpen = true;
            source.PlayOneShot(clip, 0.35f);
            return true;
        }
        return false;
    }
}
