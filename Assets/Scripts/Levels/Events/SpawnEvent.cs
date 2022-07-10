using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class SpawnEvent : LevelEvent
{
    public string enemyType;
    public float x;
    public float y;
    public string arguments;
    public List<BezierCurve> path;

    EnemyRegistry enemyRegistry;

    bool spawned;

    public SpawnEvent(string enemyType, float x, float y, string arguments, List<BezierCurve> path)
    {
        this.enemyType = enemyType;
        this.x = x;
        this.y = y;
        this.arguments = arguments;
        this.path = path;
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

        if (path != null)
        {
            FollowBezierCurves follower = enemy.GetComponent<FollowBezierCurves>();
            Debug.Assert(follower != null);

            follower.SetCurves(path);
        }

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

        List<BezierCurve> path = null;
        if (node.HasChildNodes)
        {
            XmlNode pathNode = node["Path"];
            string pathText = pathNode.InnerText;

            path = ParsePath(pathText);

            // Make sure enemy spawns at beginning of first curve of the path to avoid possible
            // ghosting issues if the x and y positions disagree
            x = path[0].p0.x;
            y = path[0].p0.y;
        }

        return new SpawnEvent(enemyType, x, y, arguments, path);
    }

    static List<BezierCurve> ParsePath(string pathText)
    {
        List<BezierCurve> curves = new List<BezierCurve>();
        foreach (string lineRaw in pathText.Split("\n"))
        {
            string line = lineRaw.Trim();
            if (line == "")
            {
                continue;
            }

            List<Vector2> points = new List<Vector2>();
            foreach (string pointStr in line.Split(" "))
            {
                var parts = pointStr.Split(",");
                float x = ParsingUtils.StringToFloat(parts[0]);
                float y = ParsingUtils.StringToFloat(parts[1]);

                points.Add(new Vector2(x, y));
            }

            Debug.Assert(points.Count == 4);

            curves.Add(new BezierCurve(points[0], points[1], points[2], points[3]));
        }

        return curves;
    }
}