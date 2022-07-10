using UnityEngine;

public class WaitTimeCondition : WaitCondition
{
    public readonly float timeS;

    float timeElapsedS;

    public WaitTimeCondition(float timeS)
    {
        this.timeS = timeS;
    }

    public override void Start()
    {
        timeElapsedS = 0.0f;
    }

    public override void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;
        timeElapsedS += delta;
    }

    public override bool IsSatisfied()
    {
        return timeElapsedS >= timeS;
    }
}