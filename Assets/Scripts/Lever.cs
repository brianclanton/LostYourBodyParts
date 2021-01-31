using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool canOpen;
    private bool closed;
    private bool boxhit;

    void Update()
    {
        if ((canOpen && Input.GetKeyDown(KeyCode.E)) || boxhit)
        {
            foreach (GameObject lockedDoor in GameObject.FindGameObjectsWithTag(tag))
            {
                if (lockedDoor != gameObject)
                {
                    Destroy(lockedDoor);
                }
            }

            if (closed)
            {
                return;
            }

            closed = true;

            var leverArm = transform.Find("lever-p");
            var pivotPoint = leverArm.transform.Find("pivot").transform.position;
            leverArm.transform.RotateAround(transform.position, 45f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canOpen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            boxhit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canOpen = false;
        }
        if (collision.gameObject.CompareTag("Block"))
        {
            boxhit = false;
        }
    }
}
