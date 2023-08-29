using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    private bool isGrounded = true;
    public float groundCheckDistance = 0.6f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement) * speed * Time.deltaTime;

        transform.Translate(movement);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, groundCheckDistance);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
