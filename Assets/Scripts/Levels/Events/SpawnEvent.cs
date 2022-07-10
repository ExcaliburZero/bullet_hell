using UnityEngine;

public class SpawnEvent : LevelEvent
{
    public string enemyType;
    public float x;
    public float y;
    public string arguments;

    EnemyRegistry enemyRegistry;

    bool spawned;

    public override void Start(EnemyRegistry enemyRegistry)
    {
        this.enemyRegistry = enemyRegistry;

        Debug.Assert(enemyType != null);
        Debug.Assert(this.enemyRegistry.enemyPrefabs.ContainsKey(enemyType));

        spawned = false;
    }

    public override void FixedUpdate()
    {
        GameObject enemyPrefab = enemyRegistry.enemyPrefabs[enemyType];

        Spawn(enemyPrefab);
        spawned = true;
    }

    public override bool IsDone()
    {
        return spawned;
    }

    GameObject Spawn(GameObject enemyPrefab)
    {
        Vector3 position = new Vector3(x, y, 0.0f);
        Quaternion rotation = new Quaternion();
        GameObject enemy = Object.Instantiate(enemyPrefab, position, rotation);

        return enemy;
    }
}