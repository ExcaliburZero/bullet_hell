using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingEnemy : MonoBehaviour
{
    public GameObject bulletResource;

    GameObject player;

    float shootCooldown = 4.0f;
    float bulletSpeed = 2.0f;

    float shotTimer;

    void Start()
    {
        player = Player.getInstance();

        // Make sure we don't shoot immediately, would conflict with FollowBezierCurve logic
        shotTimer = shootCooldown - 0.5f;
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

        EnemyBulletDirectional bullet = bulletObj.GetComponent<EnemyBulletDirectional>();
        bullet.velocity = direction;
        bullet.speed = bulletSpeed;

        return bulletObj;
    }
}
