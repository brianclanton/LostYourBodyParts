using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject lockedDoor;

    private bool canPickup;

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(lockedDoor.gameObject);
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
