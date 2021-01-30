using UnityEngine;

public class BodyPartLock : MonoBehaviour
{
    public BodyPartType type;

    private Inventory inventory;

    public void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventory.OnChangedEvent.AddListener(UpdateLockedStatus);
    }

    private void UpdateLockedStatus()
    {
        gameObject.SetActive(inventory.HasPart(type));
    }
}
