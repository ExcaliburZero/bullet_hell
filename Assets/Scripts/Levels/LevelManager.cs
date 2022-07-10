using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class LevelManager : MonoBehaviour
{
    protected LevelSpec levelSpec;
    int currentEventIndex;
    LevelEvent currentEvent;
    EnemyRegistry enemyRegistry;

    protected void Start()
    {
        enemyRegistry = EnemyRegistry.LoadFromPrefabs();
        Debug.Assert(enemyRegistry != null);

        UpdateEvent(0);
    }

    void UpdateEvent(int index)
    {
        currentEventIndex = index;
        currentEvent = levelSpec.GetEvent(index);

        if (currentEvent != null)
        {
            Debug.Assert(enemyRegistry != null);
            currentEvent.Start(enemyRegistry);
            Debug.Log("Started Event " + currentEventIndex + ": " + currentEvent);
        }
    }

    void FixedUpdate()
    {
        if (currentEvent != null && currentEvent.IsDone())
        {
            UpdateEvent(levelSpec.GetNextEventIndex(currentEventIndex));
        }

        if (currentEvent == null)
        {
            EndLevel();
            return;
        }

        currentEvent.FixedUpdate();
    }

    public abstract void EndLevel();
}
