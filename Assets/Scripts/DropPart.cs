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
        if (!movement.grounded)
        {
            return;

        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            Drop(BodyPartType.Leg);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Drop(BodyPartType.Arm);
        }
    }

    private void Drop(BodyPartType type)

    {
        if (!inventory.HasPart(type))
        {
            return;
        }

        Instantiate(bodyPartPrefabs[type], transform.position, Quaternion.identity);
        inventory.RemovePart(type);
    }
}
