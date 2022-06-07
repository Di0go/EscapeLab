using UnityEngine;

public class GameOverAnim : MonoBehaviour
{
    private Rigidbody rb;
    private bool isPlayerGrounded;
    public float fallMult;
    public float jHeight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Jump(jHeight);
    }

    private void Jump(float height)
    {
        //playerIsGrounded prevents jumping again whilst in the air
        if (isPlayerGrounded)
        {
            rb.AddForce(Vector3.up * height, ForceMode.Impulse);
            isPlayerGrounded = false;
        }

        //make the jump look more realistic - well sort of, atleast i tried
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * fallMult * Time.deltaTime;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        isPlayerGrounded = true;
    }
}
