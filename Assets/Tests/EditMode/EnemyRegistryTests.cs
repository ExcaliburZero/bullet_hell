using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyRegistryTests
{
    [Test]
    public void CanLoadEnemiesFromFileSystem()
    {
        EnemyRegistry registry = EnemyRegistry.LoadFromPrefabs();

        Assert.IsTrue(registry.enemyPrefabs.Count > 0);
    }
}
