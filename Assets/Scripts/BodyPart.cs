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
    private Sprite sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void UpdateSprite(GameObject go)
    {
        go.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprite;
    }

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            var player = GameObject.FindWithTag("Player");
            player.GetComponent<Inventory>().AddPart(type);

            var transformController = player.GetComponent<transformController>();

            if (type == BodyPartType.Arm)
            {
                UpdateSprite(transformController.leftArm);
                UpdateSprite(transformController.rightArm);
            } else if (type == BodyPartType.Leg)
            {
                UpdateSprite(transformController.leftLeg);
                UpdateSprite(transformController.rightLeg);
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
