using UnityEngine;

public class ExplosionSFX : MonoBehaviour
{
    private AudioSource src;
    public AudioClip clip;

    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WallBreakParticles.explosionSFX == true)
        {
            src.PlayOneShot(clip, 0.35f);
            WallBreakParticles.explosionSFX = false;
        }
    }
}
