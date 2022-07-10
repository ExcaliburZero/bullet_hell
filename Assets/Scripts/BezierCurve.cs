using UnityEngine;

public class BezierCurve
{
    Vector2 p0;
    Vector2 p1;
    Vector2 p2;
    Vector2 p3;

    public BezierCurve(
        Vector2 p0,
        Vector2 p1,
        Vector2 p2,
        Vector2 p3
    )
    {
        this.p0 = p0;
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
    }

    public Vector2 GetPositionAt(float t)
    {
        return BezierCurve.GetPositionAt(p0, p1, p2, p3, t);
    }

    // Formula from:
    // https://en.wikipedia.org/wiki/B%C3%A9zier_curve#Cubic_B%C3%A9zier_curves
    public static Vector2 GetPositionAt(
        Vector2 p0,
        Vector2 p1,
        Vector2 p2,
        Vector2 p3,
        float t
    )
    {
        const float ALLOWED_DEVIATION_FROM_RANGE = 0.00000001f;

        Debug.Assert(t >= (0.0f - ALLOWED_DEVIATION_FROM_RANGE));
        Debug.Assert(t <= (1.0f + ALLOWED_DEVIATION_FROM_RANGE));

        t = Mathf.Max(t, 0.0f);
        t = Mathf.Min(t, 1.0f);

        Vector2 p0Component = Mathf.Pow(1 - t, 3) * p0;
        Vector2 p1Component = 3 * Mathf.Pow(1 - t, 2) * t * p1;
        Vector2 p2Component = 3 * (1 - t) * Mathf.Pow(t, 2) * p2;
        Vector2 p3Component = Mathf.Pow(t, 3) * p3;

        return p0Component + p1Component + p2Component + p3Component;
    }
}