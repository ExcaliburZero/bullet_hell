using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyRegistry
{
    public Dictionary<string, GameObject> enemyPrefabs;

    public EnemyRegistry(Dictionary<string, GameObject> enemyPrefabs)
    {
        this.enemyPrefabs = enemyPrefabs;
    }

    public static EnemyRegistry LoadFromPrefabs()
    {
        Dictionary<string, GameObject> enemyPrefabs = new Dictionary<string, GameObject>();

        string enemyPrefabsDirAbs = Path.Combine(
            Application.dataPath, "Resources", "Prefabs", "Enemies"
        );
        string enemyPrefabsDirRel = Path.Combine(
            "Prefabs", "Enemies"
        );

        foreach (string filepath in Directory.GetFiles(enemyPrefabsDirAbs))
        {
            string filename = Path.GetFileName(filepath);
            if (!filename.EndsWith(".prefab"))
            {
                continue;
            }

            string enemyId = Path.GetFileNameWithoutExtension(filepath);

            string prefabPath = Path.Combine(enemyPrefabsDirRel, enemyId);
            GameObject enemyPrefab = Resources.Load(prefabPath) as GameObject;

            enemyPrefabs[enemyId] = enemyPrefab;
        }

        return new EnemyRegistry(enemyPrefabs);
    }
}
