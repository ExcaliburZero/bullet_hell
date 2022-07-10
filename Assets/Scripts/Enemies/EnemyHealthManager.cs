using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth;
    public GameObject deathEffect;

    int minHealth = 0;

    int currentHealth = 42;

    void Start()
    {
        Debug.Assert(maxHealth > minHealth);
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            Hit(10);
        }
    }

    void Hit(int damage)
    {
        this.currentHealth = Mathf.Max(0, this.currentHealth - damage);

        if (currentHealth == minHealth)
        {
            Die();
        }
    }

    void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, new Quaternion());
        }

        Destroy(gameObject);
    }
}
