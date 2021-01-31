using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public Collider2D tallCollider;
    public Collider2D wideCollider;
    public Collider2D fullCollider;

    private bool fullBool;
    private bool wideBool;
    private bool tallBool;
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        tallCollider.enabled = false;
        wideCollider.enabled = false;
        fullCollider.enabled = false;
    }

    private void Update()
    {
        fullBool = false;
        wideBool = false;
        tallBool = false;

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        if ((inventory.GetPartQuantity(BodyPartType.Arm) >= 1) & (inventory.GetPartQuantity(BodyPartType.Leg) >= 1)) {
            fullBool = true;
            wideBool = true;
        } 
        else if (inventory.GetPartQuantity(BodyPartType.Arm) >= 1)
        {
            wideBool = true;
        }
        else if (inventory.GetPartQuantity(BodyPartType.Leg) >= 1)
        {
            tallBool = true;
        }
    } 

    // Update is called once per frame
    void FixedUpdate()
    {
        fullCollider.enabled = fullBool;
        wideCollider.enabled = wideBool;
        tallCollider.enabled = tallBool;
    }
}
