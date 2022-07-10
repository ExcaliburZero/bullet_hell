using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingEnemy : MonoBehaviour
{
    public GameObject bulletResource;

    GameObject player;

    float shootCooldown = 4.0f;
    float bulletSpeed = 1.0f;

    float shotTimer;

    void Start()
    {
        player = Player.getInstance();
        shotTimer = 99999.0f;
    }

    void FixedUpdate()
    {
        shotTimer += Time.fixedDeltaTime;

        if (shotTimer >= shootCooldown)
        {
            shotTimer = 0.0f;
            Shoot();
        }
    }

    GameObject Shoot()
    {
        Vector2 direction = (player.transform.position - gameObject.transform.position).normalized;

        GameObject bulletObj = Instantiate(bulletResource, transform.position, new Quaternion());

        BasicEnemyBullet bullet = bulletObj.GetComponent<BasicEnemyBullet>();
        bullet.velocity = direction;
        bullet.speed = bulletSpeed;

        return bulletObj;
    }
}
