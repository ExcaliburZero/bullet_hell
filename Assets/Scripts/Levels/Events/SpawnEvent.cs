using System.Xml;
using UnityEngine;

public class SpawnEvent : LevelEvent
{
    public string enemyType;
    public float x;
    public float y;
    public string arguments;

    EnemyRegistry enemyRegistry;

    bool spawned;

    public SpawnEvent(string enemyType, float x, float y, string arguments)
    {
        this.enemyType = enemyType;
        this.x = x;
        this.y = y;
        this.arguments = arguments;
    }

    public override void Start(EnemyRegistry enemyRegistry)
    {
        Debug.Assert(enemyRegistry != null);
        this.enemyRegistry = enemyRegistry;

        Debug.Assert(enemyType != null);
        Debug.Assert(this.enemyRegistry.enemyPrefabs.ContainsKey(enemyType));

        spawned = false;
    }

    public override void FixedUpdate()
    {
        if (!spawned)
        {
            Debug.Assert(enemyRegistry != null);
            Debug.Assert(enemyRegistry.enemyPrefabs != null);

            GameObject enemyPrefab = enemyRegistry.enemyPrefabs[enemyType];

            Spawn(enemyPrefab);
            spawned = true;
        }
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

    public static new SpawnEvent FromXml(XmlNode node)
    {
        XmlAttributeCollection attributes = node.Attributes;

        XmlAttribute typeAttr = attributes["type"];
        Debug.Assert(typeAttr != null);
        string enemyType = typeAttr.Value;

        XmlAttribute xAttr = attributes["x"];
        Debug.Assert(xAttr != null);
        float x = ParsingUtils.StringToFloat(xAttr.Value);

        XmlAttribute yAttr = attributes["y"];
        Debug.Assert(yAttr != null);
        float y = ParsingUtils.StringToFloat(yAttr.Value);

        XmlAttribute argumentsAttr = attributes["arguments"];
        Debug.Assert(argumentsAttr != null);
        string arguments = argumentsAttr.Value;

        return new SpawnEvent(enemyType, x, y, arguments);
    }
}