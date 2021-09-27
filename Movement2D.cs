using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    Rigidbody2D rb;

    //Speed and Jump 
    public int speed;
    public int jumpForce;

    //Grounded Check
    //IMPORTANT! You should add a Layer named [Ground]! And select Ground layer for "Ground"!
    bool isGrounded = false; 
    public Transform isGroundedChecker; 
    public float checkGroundRadius; 
    public LayerMask groundLayer;

    //Jump Count in One Time [ex. Double Jump - Tripple Jump - Quadra Jump]
    public int JumpCount;
    int JumpCountSaver;

    void Start()
    {
        JumpCountSaver = JumpCount;
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        Move();
        Jump();     
        CheckIfGrounded();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && JumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            JumpCount--;
        }
    }

    void CheckIfGrounded() 
    { 
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer); 

        if (collider != null) 
        { 
            isGrounded = true; 
            //Reset Jump Count when Grounded
            JumpCount = JumpCountSaver;
        }   

        else 
        { 
            isGrounded = false; 
        } 
    }
}
