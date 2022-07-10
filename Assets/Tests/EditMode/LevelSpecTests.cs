using System.Collections;
using System.Collections.Generic;
using System.Xml;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LevelSpecTests
{
    [Test]
    public void ParsesLevelWithEmptyEventsList()
    {
        string filepath = TestUtil.DataFile("empty_level.xml");

        XmlDocument xml = new XmlDocument();
        xml.Load(filepath);
        LevelSpec levelSpec = LevelSpec.FromXml(xml);

        Assert.AreEqual(0, levelSpec.events.Count);
    }
}
