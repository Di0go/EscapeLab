using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Vector3 rotationSpeed;
    private Vector2 dir;
    public float jHeight;
    public float fallMult;
    private Rigidbody rb;
    private bool jumpInput;
    private float hInput, vInput;
    private bool isPlayerGrounded;

    void Start()
    {
        speed = 5f;
        jHeight = 3.5f;
        fallMult = 2.5f;
        isPlayerGrounded = true;
        rb = GetComponent<Rigidbody>();
        rotationSpeed = new Vector3(0, 250, 0);
    }

    void Update()
    {
        jumpInput = Input.GetButton("Jump");
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        //.normalized so diagnonal speed and normal speed are the same
        dir = new Vector2(hInput, vInput).normalized;
    }

    void FixedUpdate()
    {
        MovePlayer();
        Jump(jHeight);
    }

    private void MovePlayer()
    {
        //credits to Yoreki (https://forum.unity.com/threads/can-not-move-and-rotate-at-the-same-time.734438/)

        Quaternion deltaRotation = Quaternion.Euler(dir.x * rotationSpeed * Time.deltaTime);

        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.MovePosition(rb.position + transform.forward * speed * dir.y * Time.deltaTime);
    }

    private void Jump(float height)
    {
        //playerIsGrounded prevents jumping again whilst in the air
        if (jumpInput && isPlayerGrounded)
        {
            rb.AddForce(new Vector2(0, height), ForceMode.VelocityChange);
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * fallMult * Time.deltaTime;
        }
    }

    //collision checkers
    private void OnCollisionEnter(Collision collision)
    {
        //use the tag "Floor" in every floor (duh?)
        if (collision.gameObject.tag == "Floor")
        {
            isPlayerGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //use the tag "Floor" in every floor (duh?)
        if (collision.gameObject.tag == "Floor")
        {
            isPlayerGrounded = false;
        }
    }
}