using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public Dictionary<BodyPartType, int> parts = new Dictionary<BodyPartType, int>();

    public UnityEvent OnChangedEvent;

    private void Awake()
    {
        if (OnChangedEvent == null)
        {
            OnChangedEvent = new UnityEvent();
        }
    }

    public void AddPart(BodyPartType type)
    {
        if (parts.ContainsKey(type))
        {
            parts[type]++;
        }
        else
        {
            parts.Add(type, 1);
        }

        OnChangedEvent.Invoke();
    }

    public void RemovePart(BodyPartType type)
    {
        if (!parts.ContainsKey(type))
        {
            return;
        }

        parts[type]--;
        OnChangedEvent.Invoke();
    }

    public int GetPartQuantity(BodyPartType type)
    {
        return parts.ContainsKey(type) ? parts[type] : 0;
    }

    public bool HasPart(BodyPartType type)
    {
        return GetPartQuantity(type) != 0;
    }
}
