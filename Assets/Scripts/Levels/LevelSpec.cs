using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LevelSpec
{
    public List<LevelEvent> events;

    public LevelSpec(List<LevelEvent> events)
    {
        this.events = events;
    }

    public LevelEvent GetEvent(int index)
    {
        if (index < events.Count)
        {
            return events[index];
        }
        else
        {
            return null;
        }
    }

    public int GetNextEventIndex(int index)
    {
        return index + 1;
    }

    public static LevelSpec FromXml(XmlDocument doc)
    {
        List<LevelEvent> events = new List<LevelEvent>();

        XmlNodeList eventsNodes = doc.GetElementsByTagName("Events");
        Debug.Assert(eventsNodes.Count == 1);
        XmlNode eventsNode = eventsNodes[0];

        foreach (XmlNode eventNode in eventsNode.ChildNodes)
        {
            LevelEvent e = LevelEvent.FromXml(eventNode);
            events.Add(e);
        }

        return new LevelSpec(events);
    }
}
