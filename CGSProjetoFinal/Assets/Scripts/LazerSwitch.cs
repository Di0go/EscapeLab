using UnityEngine;

public class LazerSwitch : MonoBehaviour
{
    private GameObject[] Lazers;
    void Start()
    {
        Lazers = GameObject.FindGameObjectsWithTag("Lazer");
    }

    private void OnCollisionStay(Collision collision)
    {
        SwitchOff();
    }

    private void OnCollisionExit(Collision collision)
    {
        SwitchOn();
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
