using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject[] lockedDoors;

    private bool canPickup;

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            foreach (var lockedDoor in lockedDoors)
            {
                Destroy(lockedDoor.gameObject);
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
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
