using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager01 : LevelManager
{
    // TODO: is 'new' correct to use here? Why not 'override'?
    protected new void Start()
    {
        levelSpec = LevelSpec.ReadLevelSpec("spawn_level.xml");
        base.Start();
    }

    public override void EndLevel()
    {

    }
}
