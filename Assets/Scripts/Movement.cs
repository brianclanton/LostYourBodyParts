using UnityEngine;

public class Movement : MonoBehaviour
{
    const float GroundedRadius = .1f;

    public float speed = 1f;
    public float jumpForce = 200f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rigidBody;
    private Inventory inventory;

    private float xInput;
    private bool jump;
    private bool facingRight = true;
    private bool grounded;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        // Check if grounded
        grounded = false;
        Collider2D[] groundColliders = Physics2D.OverlapCircleAll(groundCheck.position, GroundedRadius, groundLayer);

        for (int i = 0; i < groundColliders.Length; i++)
        {
            if (groundColliders[i].gameObject != gameObject)
            {
                grounded = true;
                break;
            }
        }


        // Move player
        rigidBody.velocity = new Vector2(xInput * speed, rigidBody.velocity.y);

        if (jump)
        {
            jump = false;
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }

        if (xInput > 0 && !facingRight || xInput < 0 && facingRight)
        {
            Flip();
        }
    }
        
    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private bool CanJump()
    {
        return grounded && inventory.HasPart(BodyPartType.Leg);
    }
}
