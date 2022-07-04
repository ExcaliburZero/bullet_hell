using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float sneakMultiplier = 0.5f;
    public string sneakButton = "Fire2";

    public Rigidbody2D rb;

    Vector2 movement;
    bool isSneaking = false;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        isSneaking = Input.GetButton(sneakButton);
    }

    void FixedUpdate()
    {
        // Move position based on user inputs
        float movementMultiplier = 1.0f;
        if (isSneaking) {
            movementMultiplier = sneakMultiplier;
        }

        rb.MovePosition(
            rb.position + movement * moveSpeed * movementMultiplier * Time.fixedDeltaTime
        );
    }
}
