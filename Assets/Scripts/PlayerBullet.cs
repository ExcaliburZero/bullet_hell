using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Vector2 velocity;
    public float speed;

    public List<string> nonCollideableTags = new List<string>(){"Player", "PlayerBullet"};

    void FixedUpdate() {
        transform.Translate(velocity * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (nonCollideableTags.Contains(collision.tag)) {
            //Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
    }
}
