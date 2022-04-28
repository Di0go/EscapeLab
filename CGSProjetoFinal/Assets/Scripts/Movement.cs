using UnityEngine;

public class Movement : MonoBehaviour
{
    //vars
    [SerializeField] private float speed = 100f;
    private Vector3 movement;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //normalized prevents faster movement if two inputs are used at the same time
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        Move(movement);
    }

    private void Move(Vector3 dir)
    {
        rb.velocity = dir * speed * Time.deltaTime;
    }
}
