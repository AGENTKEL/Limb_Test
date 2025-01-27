using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private Animator animator;
    private Rigidbody rb;

    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from WASD or arrow keys
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Create a movement vector based on input
        movement = new Vector3(horizontal, 0f, vertical).normalized;

        // Update animator "Run" bool based on movement
        bool isRunning = movement.magnitude > 0;
        animator.SetBool("Run", isRunning);
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody
        if (movement != Vector3.zero)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            // Rotate the player to face the movement direction
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, 720 * Time.fixedDeltaTime);
        }
    }
}
