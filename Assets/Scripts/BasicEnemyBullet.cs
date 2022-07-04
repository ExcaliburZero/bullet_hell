using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBullet : MonoBehaviour
{
    public Vector2 velocity;
    public float speed;

    public List<string> nonCollideableTags = new List<string>(){"Player", "PlayerBullet"};
    public List<string> destoryCollideableTags = new List<string>(){"ScreenBorder"};

    void FixedUpdate() {
        transform.Translate(velocity * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Collided with a: " + collision.tag);
        if (nonCollideableTags.Contains(collision.tag)) {
            //Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        } else if (destoryCollideableTags.Contains(collision.tag)) {
            Debug.Log("Destroyed");
            Destroy(this.gameObject);
        }
    }
}
