using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool canPickup;

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            // TODO: Apply coin to player
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
