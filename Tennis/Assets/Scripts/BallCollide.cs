using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollide : MonoBehaviour
{

    private Vector3 previousPosition;
    private Vector3 currentVelocity;
    private Vector3 swingDirection;
    public float threshold = .05f;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        CalculateSwingDirection();
        Debug.DrawRay(transform.position, swingDirection * 2, Color.red); // Visualize the direction

    }

    private void FixedUpdate()
    {
        //CalculateSwingDirection();
        //Debug.DrawRay(transform.position, swingDirection * 2, Color.red); // Visualize the direction

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TennisBall")
        {
            Debug.Log("Ball collision detected");
            Rigidbody rb = collision.rigidbody;
            Vector3 force = swingDirection * 10f;
            rb.AddForce(force, ForceMode.VelocityChange);

        }
    }
    void CalculateSwingDirection()
    {
        Vector3 currentPosition = transform.position;
        Vector3 velocity = (currentPosition - previousPosition) / Time.deltaTime;

        if (velocity.magnitude > threshold)
        {
            swingDirection = velocity.normalized;
        }
        previousPosition = currentPosition;
    }
}
