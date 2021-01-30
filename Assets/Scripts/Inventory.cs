using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<BodyPartType, int> parts = new Dictionary<BodyPartType, int>();

    public void AddPart(BodyPartType type)
    {
        if (parts.ContainsKey(type))
        {
            parts[type]++;
            return;
        }

        parts.Add(type, 1);
    }

    public void RemovePart(BodyPartType type)
    {
        if (!parts.ContainsKey(type))
        {
            return;
        }

        parts[type]--;
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
