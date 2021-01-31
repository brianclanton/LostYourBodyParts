using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ImmovableWithoutArms : MonoBehaviour
{
    public int armsRequired = 1;
    public float movementThreshold = 0.5f;

    private Inventory inventory;
    private Rigidbody2D rigidBody;
    private AudioSource audioSource;

    public void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventory.OnChangedEvent.AddListener(UpdateMass);

        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        if (armsRequired > 1)
        {
            audioSource.pitch = 0.8f;
        }
    }

    private void UpdateMass() {
        rigidBody.mass = inventory.GetPartQuantity(BodyPartType.Arm) >= armsRequired ? 1 : 100;
    }

    private void Update()
    {
        var absX = Mathf.Abs(rigidBody.velocity.x);

        if (!audioSource.isPlaying && absX >= movementThreshold)
        {
            audioSource.Play();
        } else if (audioSource.isPlaying && absX < movementThreshold)
        {
            audioSource.Pause();
        }
    }
}
