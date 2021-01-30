using UnityEngine;

public class DropPart : MonoBehaviour
{

    public BodyPartCollection bodyPartPrefabs;
    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Drop(BodyPartType.Leg);
        }
    }

    private void Drop(BodyPartType type)

    {
        if (!inventory.HasPart(type))
        {
            return;
        }

        Debug.Log("Yagga");

        // TODO: Throw the part behind you
        Instantiate(bodyPartPrefabs[type], transform.position, Quaternion.identity);
        inventory.RemovePart(type);
    }
}
