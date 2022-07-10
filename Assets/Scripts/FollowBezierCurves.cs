using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBezierCurves : MonoBehaviour
{
    public GameObject p0;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;

    public float movementSpeed = 0.2f;

    List<BezierCurve> curves;

    int currentCurve;
    float progress;

    const float START_CURVE = 0.0f;
    const float FINISHED_CURVE = 1.0f;

    void Start()
    {
        currentCurve = 0;
        progress = 0.0f;

        Vector2 p0 = this.p0.transform.position;
        Vector2 p1 = this.p1.transform.position;
        Vector2 p2 = this.p2.transform.position;
        Vector2 p3 = this.p3.transform.position;

        curves = new List<BezierCurve>() { new BezierCurve(p0, p1, p2, p3) };
    }

    void FixedUpdate()
    {
        progress += Time.fixedDeltaTime * movementSpeed;

        if (progress >= FINISHED_CURVE)
        {
            currentCurve += 1;
            progress = START_CURVE;
        }

        if (currentCurve < curves.Count)
        {
            gameObject.transform.position = CalcNewPosition();
        }
    }

    Vector2 CalcNewPosition()
    {
        return curves[currentCurve].GetPositionAt(progress);
    }

    public void SetCurves(List<BezierCurve> curves)
    {
        this.curves = curves;
    }
}
