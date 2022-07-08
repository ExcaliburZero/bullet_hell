using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth = 100;

    int minHealth = 0;
    int currentHealth = 42;

    void Start() {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "EnemyBullet") {
            Hit(10);
        } else if (collision.tag == "Enemy") {
            Hit(10);
        }
    }

    void Hit(int damage) {
        this.currentHealth = Math.Max(0, this.currentHealth - damage);
        Debug.Log("currentHealth = " + this.currentHealth);
        if (this.currentHealth == this.minHealth) {
            Die();
        }
    }

    void Die() {
        Destroy(this.gameObject);
    }
}
