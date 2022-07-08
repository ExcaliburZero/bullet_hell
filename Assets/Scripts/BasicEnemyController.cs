using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    public GameObject bulletResource;

    float shootCooldown = 0.2f;
    float bulletSpeed = 1.0f;

    float timer = 999999.0f;
    int offsetIndex;
    List<float> offsets = new List<float>() { 0.0f, 5.0f, 10.0f, 5.0f, 0.0f, -5.0f, -10.0f, -5.0f };

    void FixedUpdate() {
        timer += Time.fixedDeltaTime;

        if (timer >= shootCooldown) {
            timer = 0.0f;

            float offsetDeg = offsets[offsetIndex];
            Debug.Log("offsetDeg = " + offsetDeg);

            ShootBulletsSimple(8, 180.0f + offsetDeg, 360.0f + offsetDeg);

            offsetIndex = NextOffsetIndex(offsetIndex);
        }
    }

    int NextOffsetIndex(int current) {
        current += 1;

        if (current == offsets.Count) {
            current = 0;
        }

        return current;
    }

    List<GameObject> ShootBulletsSimple(int numBullets, float startAngleDeg, float endAngleDeg) {
        Debug.Assert(numBullets >= 1);
        Debug.Assert(endAngleDeg >= startAngleDeg);

        float incrementDeg = (endAngleDeg - startAngleDeg) / numBullets;

        return ShootBullets(numBullets, startAngleDeg, endAngleDeg, incrementDeg);
    }

    List<GameObject> ShootBullets(int numBullets, float startAngleDeg, float endAngleDeg, float incrementDeg) {
        Debug.Assert(numBullets >= 1);

        List<GameObject> bullets = new List<GameObject>();

        float angleDeg = startAngleDeg;
        bool startLessThanEnd = startAngleDeg < endAngleDeg;
        bool done = false;
        while (!done) {
            Vector2 direction = Vector2FromAngle(angleDeg);
            bullets.Add(ShootBullet(direction));

            angleDeg += incrementDeg;

            if (startLessThanEnd && angleDeg > endAngleDeg) {
                done = true;
            } else if (!startLessThanEnd && angleDeg <= endAngleDeg) {
                done = true;
            }
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
