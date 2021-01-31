using UnityEngine;

public class Key : MonoBehaviour
{
    private GameObject[] lockedDoors;

    private bool canPickup;

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            lockedDoors = GameObject.FindGameObjectsWithTag(this.tag);
            foreach (GameObject lockedDoor in lockedDoors)
            {
                Destroy(lockedDoor);
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
