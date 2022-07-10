using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDirectional : MonoBehaviour
{
    public Vector2 velocity;
    public float speed;

    void FixedUpdate()
    {
        SetRotation(velocity.normalized);

        // Don't use transform.Translate since it would not work due to rotation of the object
        Vector2 movement = velocity * speed * Time.fixedDeltaTime;
        Vector3 newPosition = gameObject.transform.position + new Vector3(movement.x, movement.y, 0.0f);
        gameObject.transform.position = newPosition;
    }

    void SetRotation(Vector2 direction)
    {
        float angle = Vector2.SignedAngle(Vector2.up, direction);

        gameObject.transform.localEulerAngles = new Vector3(0.0f, 0.0f, angle + 180.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
