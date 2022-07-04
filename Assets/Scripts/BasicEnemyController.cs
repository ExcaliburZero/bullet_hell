using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    public GameObject bulletResource;

    float shootCooldown = 3.0f;
    float bulletSpeed = 1.0f;

    float timer = 999999.0f;
    Vector2 bulletVelocity = new Vector2(0.0f, -1.0f);

    void FixedUpdate() {
        timer += Time.fixedDeltaTime;

        if (timer >= shootCooldown) {
            timer = 0.0f;

            ShootBullet();
        }
    }

    GameObject ShootBullet() {
        // TODO: create new transform using only the position
        GameObject bulletObj = Instantiate(bulletResource, transform.position, transform.rotation);

        BasicEnemyBullet bullet = bulletObj.GetComponent<BasicEnemyBullet>();
        bullet.velocity = bulletVelocity;
        bullet.speed = bulletSpeed;

        return bulletObj;
    }
}
