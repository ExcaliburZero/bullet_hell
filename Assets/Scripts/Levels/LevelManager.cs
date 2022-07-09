using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class LevelManager : MonoBehaviour
{
    LevelSpec levelSpec;
    int currentEventIndex;
    LevelEvent currentEvent;

    void Start()
    {
        UpdateEvent(0);
    }

    void UpdateEvent(int index)
    {
        currentEventIndex = index;
        currentEvent = levelSpec.GetEvent(index);
    }

    void FixedUpdate()
    {
        if (currentEvent.IsDone())
        {
            UpdateEvent(levelSpec.GetNextEventIndex(currentEventIndex));
            if (currentEvent != null)
            {
                currentEvent.Start();
            }
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
