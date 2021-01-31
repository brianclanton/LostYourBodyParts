using UnityEngine;

public class ImmovableWithoutArms : MonoBehaviour
{
    public int armsRequired = 1;

    private Inventory inventory;
    private Rigidbody2D rigidBody;

    public void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventory.OnChangedEvent.AddListener(UpdateMass);

        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void UpdateMass() {
        rigidBody.mass = inventory.GetPartQuantity(BodyPartType.Arm) >= armsRequired ? 1 : 100;
    }
}
