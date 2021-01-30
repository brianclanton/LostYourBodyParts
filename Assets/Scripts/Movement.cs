using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 200f;
    private float xInput;
    private bool jump;
    private Rigidbody2D rigidBody;
    private Inventory inventory;
    private bool facingRight = true;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(xInput * speed, rigidBody.velocity.y);

        if (jump && CanJump())
        {
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
        return inventory.HasPart(BodyPartType.Leg);
    }
}
