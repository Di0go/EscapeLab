using UnityEngine;

public class Movement : MonoBehaviour
{
    //vars
    public bool isPlayerGrounded;

    [SerializeField] private float jumpHeight;
    [SerializeField] private float speed;

    private bool jumpInput;

    private Vector3 movement;
    private Rigidbody rb;

    void Start()
    {
        jumpHeight = 4.5f;
        rb = GetComponent<Rigidbody>();
        isPlayerGrounded = false;
        speed = 3f;
    }

    void Update()
    {
        //normalizing the vector prevents faster movement if two inputs are used at the same time
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        jumpInput = Input.GetButton("Jump");
    }

    void FixedUpdate()
    {
        Move(movement);
        Jump(jumpHeight);
    }

    private void Move(Vector3 dir)
    {
        //ignore visual studio's recomendation
        transform.Translate(speed * Time.deltaTime * dir);
    }
    private void Jump(float height)
    {
        // DEBUG
        // Debug.Log("Input: " + jumpInput);
        // Debug.Log("Value: " + playerIsGrounded);
        // DEBUG

        //playerIsGrounded prevents jumping again while in the air (can be extended to support double jump if necessary)
        if (jumpInput && isPlayerGrounded) 
            rb.velocity = new Vector3(0, height, 0);
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
