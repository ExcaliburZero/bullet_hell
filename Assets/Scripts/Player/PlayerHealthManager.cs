using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    int maxHealth = 100;
    int minHealth = 0;
    float invincibilityTime = 5.0f;

    int currentHealth = 42;

    float remainingInvinsibilityTime = 0.0f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        this.remainingInvinsibilityTime = Math.Max(0.0f, this.remainingInvinsibilityTime - Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            Hit(10);
        }
        else if (collision.tag == "Enemy")
        {
            Hit(10);
        }
    }

    public bool IsInvincible()
    {
        // Note: This floating point comparison is safe, since we only every update the
        // invincibility time counter in FixedUpdate where we use Math.Max to check it against
        // 0.0f.
        return this.remainingInvinsibilityTime > 0.0f;
    }

    void Hit(int damage)
    {
        if (IsInvincible())
        {
            // Can't take damage while invincible
            return;
        }

        this.currentHealth = Math.Max(0, this.currentHealth - damage);
        Debug.Log("currentHealth = " + this.currentHealth);

        EnterInvincibility(invincibilityTime);

        if (this.currentHealth == this.minHealth)
        {
            Die();
        }
    }

    void EnterInvincibility(float time)
    {
        this.remainingInvinsibilityTime = time;
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
