using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<BodyPartType, int> inventory = new Dictionary<BodyPartType, int>();

    public void AddPart(BodyPartType type)
    {
        if (inventory.ContainsKey(type))
        {
            inventory[type]++;
            return;
        }

        inventory.Add(type, 1);
    }

    public void RemovePart(BodyPartType type)
    {
        if (!inventory.ContainsKey(type))
        {
            return;
        }

        inventory[type]--;
    }
}
