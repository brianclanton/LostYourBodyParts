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

    private Sprite GetNestedSprite(GameObject go)
    {
        return go.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }

    private void Drop(BodyPartType type)
    {
        if (!inventory.HasPart(type))
        {
            return;
        }

        var newPart = Instantiate(bodyPartPrefabs[type], transform.position, Quaternion.identity);
        var transformController = GameObject.FindWithTag("Player").GetComponent<transformController>();
        var newPartSpriteRenderer = newPart.GetComponent<SpriteRenderer>();

        if (type == BodyPartType.Arm)
        {
            newPartSpriteRenderer.sprite = GetNestedSprite(transformController.leftArm);
        }
        else if (type == BodyPartType.Leg)
        {
            newPartSpriteRenderer.sprite = GetNestedSprite(transformController.leftLeg);
        }

        inventory.RemovePart(type);
    }
}
