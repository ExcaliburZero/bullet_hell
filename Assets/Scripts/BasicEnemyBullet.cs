using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBullet : MonoBehaviour
{
    public Vector2 velocity;
    public float speed;

    void FixedUpdate()
    {
        transform.Translate(velocity * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with a: " + collision.tag);
    }
}
