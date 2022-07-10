using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBezierCurves : MonoBehaviour
{
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
    }

    void FixedUpdate()
    {
        if (curves == null || currentCurve >= curves.Count)
        {
            return;
        }

        progress += Time.fixedDeltaTime * movementSpeed;

        if (progress >= FINISHED_CURVE)
        {
            currentCurve += 1;
            progress = START_CURVE;
        }

        if (currentCurve < curves.Count)
        {
            Vector2 newPosition = CalcNewPosition();
            gameObject.transform.position = new Vector3(newPosition.x, newPosition.y, 0.0f);
        }
    }

    Vector2 CalcNewPosition()
    {
        return curves[currentCurve].GetPositionAt(progress);
    }

    public void SetCurves(List<BezierCurve> curves)
    {
        Debug.Assert(curves != null);
        this.curves = curves;
    }
}
