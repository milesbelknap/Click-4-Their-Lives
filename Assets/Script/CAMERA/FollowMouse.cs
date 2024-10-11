using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    public Rigidbody2D rb;

    public float moveSpeed = 5f;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        
        movement.y = Input.GetAxis("Vertical");

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
