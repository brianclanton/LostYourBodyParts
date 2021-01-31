using UnityEngine;

public static class Collectibles
{
    public static int count { get; private set; }
    public static int levelStartCount { get; private set; }

    public static void AddCollectible()
    {
        count++;
    }

    public static void UpdateLevelStartCount()
    {
        levelStartCount = count;
    }

    public static void ResetCount()
    {
        count = levelStartCount;
    }
}
