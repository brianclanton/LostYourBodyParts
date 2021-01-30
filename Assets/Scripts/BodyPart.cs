using UnityEngine;

public enum BodyPartType
{
    Leg,
    Arm,
}

public class BodyPart : MonoBehaviour
{
    public BodyPartType type;

    private bool canPickup;

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Yeet");
            GameObject.FindWithTag("Player").GetComponent<Inventory>().AddPart(type);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPickup = false;
        }
    }
}
