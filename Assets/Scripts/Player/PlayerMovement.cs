using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5.0f;
    float sneakMultiplier = 0.5f;
    string sneakButton = "Fire2";

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
        if (isSneaking)
        {
            movementMultiplier = sneakMultiplier;
        }

        transform.Translate(
            movement * moveSpeed * movementMultiplier * Time.fixedDeltaTime
        );
    }
}
