using UnityEngine;

public static class Collectibles
{
    public static int count { get; private set; }

    public static void AddCollectible()
    {
        count++;
    }
}
