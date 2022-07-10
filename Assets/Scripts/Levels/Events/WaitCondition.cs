public abstract class WaitCondition
{
    public abstract void Start();
    public abstract void FixedUpdate();
    public abstract bool IsSatisfied();
}