using UnityEngine;

public class LazerSwitch : MonoBehaviour, IInteractable
{
    private GameObject[] Lazers;
    public string intText { get ;}

    void Start()
    {
        Lazers = GameObject.FindGameObjectsWithTag("Lazer");
    }

    public bool Interact()
    {
        if (Lazers[0].activeSelf == true) SwitchOff(); else SwitchOn();
        return true;
    }

    private void SwitchOff()
    {
        foreach (var lazer in Lazers)
        {
            lazer.SetActive(false);
        }
    }

    private void SwitchOn()
    {
        foreach (var lazer in Lazers)
        {
            lazer.SetActive(true);
        }
    }
}
