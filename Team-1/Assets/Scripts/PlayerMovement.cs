using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumbleGround;
    private BoxCollider2D coll;
    
    public float runSpeed;
    public float jumpPower;
    public Transform tf;
    public float wallCheckDistance;
    public float groundCheckDistance;
    public LayerMask wallLayer;
    public int isRight = 1;
    public float wallingSpeed = 0.2f;
    public float walljumppower;
    public bool isWallJump;
    bool isStunned = false;
    public float stunnedPower;
    private enum MovementState { idle, running, jumping, falling, walling };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            if (IsGrounded()) {
                isStunned = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) { //충돌관련

        if (collision.gameObject.tag == "Ground") {//천장에 충돌하면 스턴상태 적용 및 움직임 튕김
            if (isCeiling()) {
                isStunned = true;
                Debug.Log("Ceiling Stunned!");
            }
        }

        if (collision.collider.CompareTag("trap")) {//trap에 충돌하면 스턴상태 적용 및 움직임 변화
            isStunned = true;
            Debug.Log("Box Collided!");
        }
        Debug.Log("Collision is made:" + collision.gameObject.name);
    }
    // Update is called once per frame
    void Update() {
        if (isStunned)
        {
            if (isRight == 1)
            {
                FlipPlayer();
                rb.velocity = new Vector2(isRight * stunnedPower, -1f * stunnedPower);
            }
            else
            {
                FlipPlayer();
                rb.velocity = new Vector2(isRight * stunnedPower, -1f * stunnedPower);

            }
        }
        else
        {
            float dirX = Input.GetAxisRaw("Horizontal");
            if (!isWallJump)
                rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);

            if (IsWall() && !(IsGrounded()))
            {
                isWallJump = false;
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * wallingSpeed);
                if (Input.GetButtonDown("Jump"))
                {

                    CancelInvoke("FreezeX");
                    isWallJump = true;
                    Invoke("FreezeX", 1f);

                    if (isRight == 1)
                    {
                        FlipPlayer();
                    }
                    else
                    {
                        FlipPlayer();
                    }
                    rb.velocity = new Vector2(isRight * walljumppower, 0.9f * walljumppower);
                }
            }
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(0, jumpPower);
            }
            UpdateAnimationUpdate(dirX);
        }
    }

    private bool IsGrounded() {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, jumbleGround);
    }
    private bool IsWall() {
        return Physics2D.Raycast(tf.position, Vector2.right * isRight, wallCheckDistance, jumbleGround);
    }
    private bool isCeiling() {
        return Physics2D.Raycast(transform.position, Vector2.up, groundCheckDistance, jumbleGround);
    }
    void FreezeX() {
        isWallJump = false;
    }
    void FlipPlayer() {
        transform.eulerAngles = new Vector3(0, Mathf.Abs(transform.eulerAngles.y - 180), 0);
        isRight = isRight * -1;
    }

    private void UpdateAnimationUpdate(float dirX) {
        MovementState state = MovementState.idle;
        if (IsWall()) {
            //isWallJump = false;
            state = MovementState.walling;
        } else {
            if (!isWallJump)
                if (dirX > 0f) {
                    state = MovementState.running;
                    if (isRight == -1) {
                        FlipPlayer();
                    }
                } else if (dirX < 0f) {
                    state = MovementState.running;
                    if (isRight == 1) {
                        FlipPlayer();
                    }
                } else {
                    state = MovementState.idle;
                }
            if (rb.velocity.y > .1f) {
                state = MovementState.jumping;
            } else if (rb.velocity.y < -.1f) {
                state = MovementState.falling;
            }
        }
        anim.SetInteger("state", (int)state);
    }
}
