using UnityEngine;

public static class Collectibles
{
    public static int count { get; private set; }

    public static void AddCollectible()
    {
        var narrationController = GameObject.FindGameObjectWithTag("Narration").GetComponent<NarrationController>();
        narrationController.PlayNarration(count);

        count++;
    }
}
