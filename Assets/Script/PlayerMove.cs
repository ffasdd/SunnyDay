using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float goalX = 192;

    [Header("Movement Bounds (World X)")]
    [SerializeField] float minX = -14f;
    [SerializeField] float maxX = 197f;

    [SerializeField] UIManager uiManager;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    float inputX;
    bool inputY;
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
        inputY = Input.GetKeyDown(KeyCode.Space);

        spriteRenderer.flipX = inputX < 0;

        // 바닥 감지: 속도가 거의 0이고 아래로 떨어지지 않을 때 땅에 있다고 판단
        bool isGrounded = Mathf.Abs(rb.velocity.y) < 0.1f;

        animator.SetBool("IsWalking", inputX != 0 && isGrounded);

        // 점프 처리 (Update에서 처리하여 정확한 타이밍 보장)
        if (inputY && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
        // 점프 입력이 없고, 땅에 있을 때만 점프 애니메이션 종료
        else if (!inputY && isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }

        if(rb.position.x > goalX){
            Clear();
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = inputX * moveSpeed;
        rb.velocity = velocity;

        Vector2 pos = rb.position;
        float clampedX = Mathf.Clamp(pos.x, minX, maxX);
        if (!Mathf.Approximately(clampedX, pos.x))
        {
            pos.x = clampedX;
            rb.position = pos;
        }
    }

    public void Clear(){
        uiManager.OnPlayerClear();
    }
}
