using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    float Speed = 15;
    [SerializeField] private LayerMask floorLayerMask;
    float JumpTimer = 0;
    float GroundedTimer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
        GroundedTimer -= Time.deltaTime;
        print(JumpTimer);
        if (IsGrounded())
        {
            GroundedTimer = 1;
        }
        float HorizontalMovement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Speed * HorizontalMovement, rb.velocity.y);
        if (!IsGrounded())
        {
            Speed = 10;
        } else
        {
            Speed = 15;
        }
        if (Input.GetKeyDown("space"))
        {
            JumpTimer = 1;
        }
        if (Input.GetKey("space") && GroundedTimer < 1)
        {
            if(JumpTimer >= 6)
            {
                
                JumpTimer += 2;
            }
            
        } else
        {
            JumpTimer -= Time.deltaTime / 2;
        }

        if (JumpTimer > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = 2.5f;
        } else
        {
            rb.gravityScale = 1;
        }

    }

    private bool IsGrounded()
    {
        float extraHeaightRay = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeaightRay, floorLayerMask);
        return raycastHit.collider != null;
    }
}
