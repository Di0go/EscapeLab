using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //vars
    [SerializeField] protected float playerHealth;
    private Color defaultColor;

    void Start()
    {
        playerHealth = 100f;

        defaultColor = gameObject.GetComponent<Renderer>().material.color;
    }


    public void DamagePlayer(float damage)
    {
        //reduces the player's hp
        playerHealth -= damage;
        StartCoroutine(DamageAnimation(0.25f));
    }

    private IEnumerator DamageAnimation(float seconds)
    {
        //changes the color to red
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        //wait for x seconds
        yield return new WaitForSeconds(seconds);

        //changes the material back to default
        gameObject.GetComponent<Renderer>().material.color = defaultColor;
    }
}
