using UnityEngine;

public class DropPart : MonoBehaviour
{

    public BodyPartCollection bodyPartPrefabs;
    private Inventory inventory;
    private Movement movement;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && movement.grounded)
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
