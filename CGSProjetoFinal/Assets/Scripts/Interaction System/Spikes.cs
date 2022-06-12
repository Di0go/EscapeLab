using UnityEngine;

public class Spikes : MonoBehaviour, IInteractable
{
    //vars
    public HUD hud;
    public GameObject neededObj;
    private bool canDamage;
    public static bool playSound = false; 

    void Start()
    {
        canDamage = true;
    }

    public bool Interact(Interactor interactor)
    {
        if (hud.SelectedItem() == neededObj.GetComponent<IInventoryItem>())
        {
            gameObject.SetActive(false);
            playSound = true;
            return true;
        }

        return false;
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && canDamage == true)
        {
            Debug.Log("Hit");
            collision.gameObject.GetComponent<HealthSystem>().DamagePlayer(1);
            canDamage = false;

            //invoke allows us to wait x time before executing a method
            Invoke("CooldownSwitch", .75f);
        }
    }

    //lazer cooldown switcher
    private void CooldownSwitch()
    {
        canDamage = true;
    }
}
