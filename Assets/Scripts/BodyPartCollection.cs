using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu]
public class BodyPartCollection : ScriptableObject
{
    [Serializable]
    public class BodyPartPrefab
    {
        public GameObject prefab;
        public BodyPartType bodyPartType;
    }

    private Dictionary<BodyPartType, GameObject> dict;
    public BodyPartPrefab[] AllPrefabs;

    public GameObject this[BodyPartType type]
    {
        get
        {
            Init();
            return dict[type];
        }
    }

    private void Init()
    {
        if (dict != null)
            return;

        dict = new Dictionary<BodyPartType, GameObject>();

        foreach (var tile in AllPrefabs)
        {
            dict[tile.bodyPartType] = tile.prefab;
        }
    }
}