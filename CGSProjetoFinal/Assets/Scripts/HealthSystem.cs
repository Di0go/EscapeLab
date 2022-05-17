using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    //vars
    [SerializeField] protected int playerHealth;
    [SerializeField] protected Image[] hearts;

    private Color defaultColor;

    void Start()
    {
        playerHealth = 3;

        defaultColor = gameObject.GetComponent<Renderer>().material.color;

        //full hp at start
        UpdateHearts();
    }

    //updates the HP HUD
    protected void UpdateHearts()
    {
        int hCounter = 1;

        foreach (var heart in hearts)
        {
            if (hCounter <= playerHealth)
            {
                heart.color = Color.red;
            }
            else
            {
                heart.color = Color.grey;
            }
            hCounter++;
        }
    }

    public void DamagePlayer(int damage)
    {
        //reduces the player's hp
        playerHealth -= damage;
        //updates the health indicator
        UpdateHearts();
        //player damage debug animation
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
