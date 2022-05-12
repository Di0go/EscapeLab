using UnityEngine;

public class DeathBox : MonoBehaviour
{
    private GameObject targetObj;

    private void Start()
    {
        targetObj = GameObject.Find("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        targetObj.GetComponent<Player>().DamagePlayer(25f);
    }
}
