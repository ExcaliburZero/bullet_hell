using System;
using System.Xml;

abstract public class LevelEvent
{
    public abstract void Start(EnemyRegistry enemyRegistry);
    public abstract void FixedUpdate();
    public abstract bool IsDone();

    public static LevelEvent FromXml(XmlNode node)
    {
        return node.Name switch
        {
            "Wait" => WaitEvent.FromXml(node),
            _ => throw new ArgumentException("Invalid LevelEvent name: " + node.Name),
        };
    }
}
