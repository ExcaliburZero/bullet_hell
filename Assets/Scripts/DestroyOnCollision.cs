using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [Tooltip("List of tags to destroy the object when it collides with.")]
    public List<string> destoryCollideableTags = new List<string>();

    void OnTriggerEnter2D(Collider2D collision) {
        if (destoryCollideableTags.Contains(collision.tag)) {
            Destroy(this.gameObject);
        }
    }
}
