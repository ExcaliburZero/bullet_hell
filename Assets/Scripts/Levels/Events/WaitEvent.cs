using System.Collections.Generic;
using System.Linq;
using System.Xml;

public class WaitEvent : LevelEvent
{
    const float NO_TIME_CONDITION = -1.0f;

    List<WaitCondition> conditions;

    public WaitEvent(float timeS)
    {
        conditions = new List<WaitCondition>();

        if (timeS != NO_TIME_CONDITION)
        {
            conditions.Add(new WaitTimeCondition(timeS));
        }
    }

    public override void Start(EnemyRegistry enemyRegistry)
    {
        foreach (WaitCondition condition in conditions)
        {
            condition.Start();
        }
    }

    public override void FixedUpdate()
    {
        foreach (WaitCondition condition in conditions)
        {
            condition.FixedUpdate();
        }
    }

    public override bool IsDone()
    {
        var satisfied =
            from condition in conditions
            where condition.IsSatisfied()
            select condition;

        return satisfied.Count() > 0;
    }

    public static new WaitEvent FromXml(XmlNode node)
    {
        float timeS = NO_TIME_CONDITION;

        XmlAttributeCollection attributes = node.Attributes;

        XmlAttribute timeSAttr = attributes["timeS"];
        if (timeSAttr != null)
        {
            timeS = ParsingUtils.StringToFloat(timeSAttr.Value);
        }


        return new WaitEvent(timeS);
    }
}