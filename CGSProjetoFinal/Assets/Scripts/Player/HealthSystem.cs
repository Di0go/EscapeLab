using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    //vars
    protected int playerHealth;
    [SerializeField] protected Image[] hearts;
    [SerializeField] protected Sprite fullSprite;
    [SerializeField] protected Sprite emptySprite;
    [Space]
    private Material defaultMat;
    private bool canDie;
    public Material dmgMat;
    public CountdownTimer timer;
    public ParticleSystem damageParticles;

    void Start()
    {
        playerHealth = 5;

        defaultMat = gameObject.GetComponent<Renderer>().material;

        //full hp at start
        UpdateHearts();

        canDie = true;
    }

    public void Update()
    {
        if (playerHealth <= 0 && canDie || timer.timeValue <= 0 && canDie)
        {
            Destroy(gameObject.GetComponent<Movement>());
            StartCoroutine(DeathAnimation());
        }
    }


    //updates the HP HUD
    protected void UpdateHearts()
    {
        int hCounter = 1;

        foreach (var heart in hearts)
        {
            if (hCounter <= playerHealth)
            {
                heart.sprite = fullSprite;
            }
            else
            {
                heart.sprite = emptySprite;
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
        Debug.Log(-damage);
    }

    private IEnumerator DamageAnimation(float seconds)
    {
        //changes the color to red
        gameObject.GetComponent<Renderer>().material = dmgMat;
        if (!damageParticles.isPlaying) damageParticles.Play();

        //wait for x seconds
        yield return new WaitForSeconds(seconds);
        if (damageParticles.isPlaying) damageParticles.Stop();
        if (canDie)
        {
            //changes the material back to default
            gameObject.GetComponent<Renderer>().material = defaultMat;
        }
    }

    private IEnumerator DeathAnimation()
    {
        canDie = false;

        gameObject.GetComponent<Renderer>().material = dmgMat;

        gameObject.transform.Rotate(transform.position.x, transform.position.y, 90);

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("Death");
    }
}
