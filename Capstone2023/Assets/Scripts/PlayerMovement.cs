using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    private Rigidbody2D rb;
    private Animator anim;
    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);

        var horizontalAxis = movement.x == 1 || movement.x == -1;
        var verticalAxis =  movement.y == 1 || movement.y == -1;
        if(horizontalAxis || verticalAxis)
        {
            anim.SetFloat("Last Horizontal", movement.x); // setting the last horizontal param to which way we are facing
            anim.SetFloat("Last Vertical", Input.GetAxisRaw("Vertical")); // setting the last vertical param to which way we are facing
        }
    }
}
