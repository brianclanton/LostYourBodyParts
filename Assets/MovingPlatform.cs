using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject startpoint;
    public GameObject endpoint;
    public float velocity = 4f;
    public bool active = true;
    public int direction = 1;

    void FixedUpdate()
    {
        if (active)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (velocity * Time.fixedDeltaTime * direction));
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == endpoint) 
        {
            direction = -1;
        }        
        if (collision.gameObject == startpoint)
        {
            direction = 1;
        }
    }


}
