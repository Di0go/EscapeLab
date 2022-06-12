using UnityEngine;

public class SpikesAudio : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (Spikes.playSound == true)
        {
            source.PlayOneShot(clip, 0.30f);
            Spikes.playSound = false;
        }
    }
}
