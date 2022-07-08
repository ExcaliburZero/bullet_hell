using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    public GameObject bulletResource;

    float shootCooldown = 3.0f;
    float bulletSpeed = 1.0f;

    float timer = 999999.0f;

    void FixedUpdate() {
        timer += Time.fixedDeltaTime;

        if (timer >= shootCooldown) {
            timer = 0.0f;

            ShootBullets(8, 180.0f, 360.0f);
        }
    }

    List<GameObject> ShootBullets(int numBullets, float startAngleDeg, float endAngleDeg) {
        Debug.Assert(numBullets >= 1);
        Debug.Assert(endAngleDeg >= startAngleDeg);

        List<GameObject> bullets = new List<GameObject>();

        float incrementDeg = (endAngleDeg - startAngleDeg) / numBullets;
        for (float angleDeg = startAngleDeg; angleDeg <= endAngleDeg; angleDeg += incrementDeg) {
            Vector2 direction = Vector2FromAngle(angleDeg);
            bullets.Add(ShootBullet(direction));
        }

        return bullets;
    }

    GameObject ShootBullet(Vector2 direction) {
        // TODO: create new transform using only the position
        GameObject bulletObj = Instantiate(bulletResource, transform.position, transform.rotation);

        BasicEnemyBullet bullet = bulletObj.GetComponent<BasicEnemyBullet>();
        bullet.velocity = direction;
        bullet.speed = bulletSpeed;

        return bulletObj;
    }

    Vector2 Vector2FromAngle(float a) {
        a *= Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }
}
