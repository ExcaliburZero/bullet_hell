using System.Xml;
using UnityEngine;

public class WaitTimeEvent : WaitEvent
{
    public readonly float timeS;

    float timeElapsedS;

    public WaitTimeEvent(float timeS)
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

    public override bool IsDone()
    {
        return timeElapsedS >= timeS;
    }

    public static new WaitTimeEvent FromXml(XmlNode node)
    {
        XmlAttributeCollection attributes = node.Attributes;

        XmlAttribute timeSAttr = attributes["timeS"];
        Debug.Assert(timeSAttr != null);

        float timeS = ParsingUtils.StringToFloat(timeSAttr.Value);

        return new WaitTimeEvent(timeS);
    }
}