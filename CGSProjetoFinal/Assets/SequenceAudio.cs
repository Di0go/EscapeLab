using UnityEngine;

public class SequenceAudio : MonoBehaviour
{
    public Sequence sequence;
    public AudioClip correct, fail;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
            if (Sequence.audioTrigger == 1)
            {
                source.PlayOneShot(fail, 0.3f);
                Sequence.audioTrigger = 0;
            }
            else if (Sequence.audioTrigger == 2)
            {
                source.PlayOneShot(correct, 0.3f);
                Sequence.audioTrigger = 0;
        }
    }
}
