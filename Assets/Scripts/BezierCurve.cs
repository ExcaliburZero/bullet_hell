using UnityEngine;

public class BezierCurve
{
    const float LENGTH_NOT_CALCULATED = -1.0f;

    public readonly Vector2 p0;
    public readonly Vector2 p1;
    public readonly Vector2 p2;
    public readonly Vector2 p3;

    float length = LENGTH_NOT_CALCULATED;

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

    public float ApproximateLength()
    {
        if (this.length != LENGTH_NOT_CALCULATED)
        {
            return this.length;
        }

        const int NUM_SAMPLES = 20;

        float step = 1.0f / NUM_SAMPLES;

        float length = 0.0f;
        for (int i = 0; i < NUM_SAMPLES - 1; i++)
        {
            Vector2 a = GetPositionAt(i * step);
            Vector2 b = GetPositionAt((i + 1) * step);

            length += Vector2.Distance(a, b);
        }

        this.length = length;

        return length;
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