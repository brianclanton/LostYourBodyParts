using UnityEngine;

public class ImmovableWithoutArms : MonoBehaviour
{
    private Inventory inventory;
    private Rigidbody2D rigidBody;

    public void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventory.OnChangedEvent.AddListener(UpdateMass);

        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void UpdateMass() {
        rigidBody.mass = inventory.HasPart(BodyPartType.Arm) ? 1 : 100;
    }
}
