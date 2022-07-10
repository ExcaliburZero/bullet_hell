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

    [Test]
    public void ParsesLevelWithOneWaitEvent()
    {
        string filepath = TestUtil.DataFile("wait_level.xml");

        XmlDocument xml = new XmlDocument();
        xml.Load(filepath);
        LevelSpec levelSpec = LevelSpec.FromXml(xml);

        Assert.AreEqual(1, levelSpec.events.Count);
    }

    [Test]
    public void ParsesLevelWithSpawnEvent()
    {
        string filepath = TestUtil.DataFile("spawn_level.xml");

        XmlDocument xml = new XmlDocument();
        xml.Load(filepath);
        LevelSpec levelSpec = LevelSpec.FromXml(xml);

        Assert.AreEqual(2, levelSpec.events.Count);
    }

    [Test]
    public void ParsesLevelWithSpawnEventFollowPath()
    {
        string filepath = TestUtil.DataFile("spawn_level_follow_path.xml");

        XmlDocument xml = new XmlDocument();
        xml.Load(filepath);
        LevelSpec levelSpec = LevelSpec.FromXml(xml);

        Assert.AreEqual(2, levelSpec.events.Count);

        SpawnEvent spawnEvent = levelSpec.events[0] as SpawnEvent;

        Assert.AreEqual(1, spawnEvent.path.Count);
    }
}
