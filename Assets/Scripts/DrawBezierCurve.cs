using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBezierCurve : MonoBehaviour
{
    public GameObject p0;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;

    void OnDrawGizmos()
    {
        Vector2 p0 = this.p0.transform.position;
        Vector2 p1 = this.p1.transform.position;
        Vector2 p2 = this.p2.transform.position;
        Vector2 p3 = this.p3.transform.position;

        for (float t = 0.0f; t <= 1.0f; t += 0.05f)
        {
            Vector2 position = BezierCurve.GetPositionAt(p0, p1, p2, p3, t);

            Gizmos.DrawSphere(position, 0.05f);
        }

        Gizmos.DrawLine(p0, p1);
        Gizmos.DrawLine(p2, p3);
    }
}
