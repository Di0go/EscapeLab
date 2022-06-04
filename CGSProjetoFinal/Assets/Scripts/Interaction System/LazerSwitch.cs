using UnityEngine;

public class LazerSwitch : MonoBehaviour, IInteractable
{
    private GameObject[] Lazers;
    private Material defaultMat;
    public Material off;

    void Start()
    {
        Lazers = GameObject.FindGameObjectsWithTag("Lazer");
        defaultMat = gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material;
    }

    public bool Interact(Interactor interactor)
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

        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<MeshRenderer>().material = off;
        }
    }

    private void SwitchOn()
    {
        foreach (var lazer in Lazers)
        {
            lazer.SetActive(true);
        }

        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<MeshRenderer>().material = defaultMat;
        }
    }
}
