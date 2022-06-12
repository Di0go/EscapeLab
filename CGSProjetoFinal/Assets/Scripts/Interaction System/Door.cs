using UnityEngine;

public class Door : MonoBehaviour
{
    //vars
    public bool isDoorOpen;
    public GameObject door;

    private Vector3 startPos;
    private Vector3 endPos;
    private float desiredDuration;
    private float elapsedTime;

    private GameObject on;
    private GameObject off;

    private AudioSource source;
    public AudioClip clip;

    void Start()
    {
        desiredDuration = 8f;
        isDoorOpen = false;
        startPos = transform.position;
        endPos = new Vector3(transform.position.x, 25, transform.position.z); 

        on = transform.GetChild(1).GetChild(0).gameObject;
        off = transform.GetChild(1).GetChild(1).gameObject;

        on.SetActive(false);
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isDoorOpen)
        {
            OpenDoor();
            source.PlayOneShot(clip, 0.05f);
        }
    }

    private void OpenDoor()
    {
        on.SetActive(true);
        off.SetActive(false);
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;
        door.transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, percentageComplete));
    }
}
