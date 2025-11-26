using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    Rigidbody2D rb;
    float inputX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = inputX * moveSpeed;
        rb.velocity = velocity;
    }
}
