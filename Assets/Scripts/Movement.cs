using UnityEngine;

public class Movement : MonoBehaviour
{
    const float GroundedRadius = .1f;

    public float playerSpeed = 1f;
    public float jumpForce = 850f;
    public float highjumpForce = 1000f;
    public float maxSpeed = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    private Rigidbody2D rigidBody;
    private Inventory inventory;

    private float xInput;
    private bool jump;
    private bool facingRight = true;
    [HideInInspector]
    public bool grounded;

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

        // Update animation
        animator.SetBool("Jump", jump);
        animator.SetBool("Walk", grounded && rigidBody.velocity.magnitude > float.Epsilon);
        animator.SetBool("Push", false /* TODO: add check */);
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
        rigidBody.velocity = new Vector2(xInput * playerSpeed, rigidBody.velocity.y);

        // TODO: Limit y velocity to player speed
        //var velocityY = Mathf.Abs(rigidBody.velocity.y);

        //if (velocityY > maxSpeed)
        //{
        //    var brakingForce = new Vector2(0f, Mathf.Sign(velocityY) * (maxSpeed - velocityY) / Time.fixedDeltaTime);

        //    Debug.Log("Braking force: " + brakingForce.y);

        //    rigidBody.AddForce(brakingForce);
        //}

        if (jump)
        {
            if (inventory.GetPartQuantity(BodyPartType.Leg) != 1)
            {
                rigidBody.AddForce(new Vector2(0f, highjumpForce));
            }
            else
            {
                rigidBody.AddForce(new Vector2(0f, jumpForce));
            }
            jump = false;
        }

        if (xInput > 0 && !facingRight || xInput < 0 && facingRight)
        {
            Flip();
        }

        //if (rigidBody.velocity.y != 0)
        //{
        //    Debug.Log("velocity y: " + rigidBody.velocity.y);
        //}
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
