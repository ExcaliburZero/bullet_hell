using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawner : MonoBehaviour
{
    public GameObject bulletResource;

    public float bulletSpeed = 5.0f;
    public float cooldown = 0.2f;

    Vector2 bulletVelocity = new Vector2(0.0f, 1.0f);
    float timer = 9999999.0f;
    bool isShooting;

    void Update()
    {
        isShooting = Input.GetButton("Fire1");
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (isShooting && timer >= cooldown)
        {
            timer = 0.0f;

            ShootBullet();
        }
    }

    GameObject ShootBullet()
    {
        // TODO: create new transform using only the position
        GameObject bulletObj = Instantiate(bulletResource, transform.position, transform.rotation);

        PlayerBullet bullet = bulletObj.GetComponent<PlayerBullet>();
        bullet.velocity = bulletVelocity;
        bullet.speed = bulletSpeed;

        return bulletObj;
    }
}
