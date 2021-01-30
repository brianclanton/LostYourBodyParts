using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
    private float xInput;
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(xInput * speed, rigidBody.velocity.y);
    }
}
