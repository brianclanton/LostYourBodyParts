using UnityEngine;

public class transformController : MonoBehaviour
{

    public Inventory inventory;
    public GameObject player;
    public GameObject leftArm;
    public GameObject rightArm;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject ground;

    private int armCount;
    private int legCount;
    private int caseSwitch;
    private bool tall;

    private bool rArmBool;
    private bool lArmBool;
    private bool rLegBool;
    private bool lLegBool;

    private readonly float tallY = -6.2f;
    private readonly float shortY = -3.2f;

    // Update is called once per frame
    void Update()
    {
        armCount = 10 * (inventory.GetPartQuantity(BodyPartType.Arm));
        legCount = (inventory.GetPartQuantity(BodyPartType.Leg));
        caseSwitch = armCount + legCount;

        tall = false;
        rArmBool = false;
        lArmBool = false;
        rLegBool = false;
        lLegBool = false;

        switch (caseSwitch)
        {
            case 1:
                tall = true;
                lLegBool = true;
                break;
            case 2:
                tall = true;
                lLegBool = true;
                rLegBool = true;
                break;
            case 10:
                tall = false;
                rArmBool = true;
                break;
            case 11:
                tall = true;
                rArmBool = true;
                lLegBool = true;
                break;
            case 12:
                tall = true;
                rArmBool = true;
                lLegBool = true;
                rLegBool = true;
                break;
            case 20:
                tall = false;
                rArmBool = true;
                lArmBool = true;
                break;
            case 21:
                tall = true;
                rArmBool = true;
                lArmBool = true;
                lLegBool = true;
                break;
            case 22:
                tall = true;
                rArmBool = true;
                lArmBool = true;
                lLegBool = true;
                rLegBool = true;
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        leftArm.SetActive(lArmBool);
        rightArm.SetActive(rArmBool);
        leftLeg.SetActive(lLegBool);
        rightLeg.SetActive(rLegBool);

        if (tall)
        {
            ground.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + (player.transform.localScale.y)*tallY);
        }
        else
        {
            ground.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + (player.transform.localScale.y)*shortY);
        }
    }
}
