using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPartType
{
    Leg,
    Arm,
}

public class BodyPart : MonoBehaviour
{
    public BodyPartType type;
    public GameObject player;

    private bool canPickup;

    // Update is called once per frame
    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<Inventory>().AddPart(type);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(player))
        {
            canPickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(player))
        {
            canPickup = false;
        }
    }
}
