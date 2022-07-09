
public class SpawnEvent : LevelEvent
{
    public string enemyType;
    public float x;
    public float y;
    public string arguments;

    bool spawned;

    public override void Start()
    {
        spawned = false;
    }

    public override void FixedUpdate()
    {
        Spawn();
        spawned = true;
    }

    public override bool IsDone()
    {
        return spawned;
    }

    void Spawn() { }
}