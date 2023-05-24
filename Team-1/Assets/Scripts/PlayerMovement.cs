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
    private float dirX = 0f;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumbleGround;
    private BoxCollider2D coll;
    public float runSpeed;
    public float jumpPower;

    public Transform wallCheck;
    public float wallCheckDistance;
    public LayerMask wallLayer;
    public int isRight = 1;
    bool isWall;
    public float wallingSpeed = 0.2f;
    public float walljumppower;
    public bool isWallJump;
    bool isStunned = false;
    public bool blockInput;

    private enum MovementState { idle, running, jumping, falling, walling };
    MovementState state = MovementState.idle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        wallLayer = GetComponent<LayerMask>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            isStunned = false;
            blockInput = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Box")
        {
            isStunned = true;
            blockInput = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            Debug.Log("Box Collided!");
            if (isRight == 1)
            {
                FlipPlayer();
                rb.AddForce(new Vector2(isRight * -300, 100), ForceMode2D.Force);
            }
            else if (isRight == -1)
            {
                FlipPlayer();
                rb.AddForce(new Vector2(isRight * -300, 100), ForceMode2D.Force);
            }
        }
        Debug.Log("Collision is made:" + collision.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (blockInput)
        {
            float dirX = Input.GetAxis("Horizontal");
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

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumbleGround);
    }
    private bool IsWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * isRight, wallCheckDistance, jumbleGround);
    }
    void FreezeX()
    {
        isWallJump = false;
    }
    void FlipPlayer()
    {
        transform.eulerAngles = new Vector3(0, Mathf.Abs(transform.eulerAngles.y - 180), 0);
        isRight = isRight * -1;
    }

    private void UpdateAnimationUpdate(float dirX)
    {
        MovementState state = MovementState.idle;
        if (IsWall())
        {
            //isWallJump = false;
            state = MovementState.walling;
        }
        else
        {
            if (!isWallJump)
                if (dirX > 0f)
                {
                    state = MovementState.running;
                    if (isRight == -1)
                    {
                        FlipPlayer();
                    }
                }
                else if (dirX < 0f)
                {
                    state = MovementState.running;
                    if (isRight == 1)
                    {
                        FlipPlayer();
                    }
                }
                else
                {
                    state = MovementState.idle;
                }
            if (rb.velocity.y > .1f)
            {
                state = MovementState.jumping;
            }
            else if (rb.velocity.y < -.1f)
            {
                state = MovementState.falling;
            }
        }

        anim.SetInteger("state", (int)state);
    }

    void BlockInput()
    {
        blockInput = true;
    }

    void UnBlockInput()
    {
        blockInput = false;
    }
}
