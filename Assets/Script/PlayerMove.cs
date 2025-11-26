using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    float inputX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        
        spriteRenderer.flipX = inputX < 0;

        if(inputX != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = inputX * moveSpeed;
        rb.velocity = velocity;
    }
}
