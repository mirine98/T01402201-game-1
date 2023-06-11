using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumbleGround;
    private BoxCollider2D coll;

    [SerializeField]
    private NumCoin numCoin;
    public bool getCoin = false;

    private float runSpeed = 9f;
    public float jumpPower;
    public Transform tf;
    public float wallCheckDistance;
    public float groundCheckDistance;
    public LayerMask wallLayer;
    public int isRight = 1;
    private float wallingSpeed = 0.85f;
    public float walljumppower;
    public bool isWallJump;
    bool isStunned = false;
    private float stunnedPower = 9f;

    [SerializeField] private AudioSource jumpsound;
    [SerializeField] private AudioSource hitsound;
    [SerializeField] private AudioSource stunmusic;
    
    private enum MovementState { idle, running, jumping, falling, walling, stun};

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            if (IsGrounded()) {
                stunmusic.Stop();
                isStunned = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Coin" || collision.gameObject.tag == "FinalCoin") {
            numCoin.GetCoin();
            getCoin = true;
            collision.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) { //충돌관련

        if (collision.gameObject.tag == "Ground") {//천장에 충돌하면 스턴상태 적용 및 움직임 튕김
            if (isCeiling()) {
                hitsound.Play();
                isStunned = true;
                Debug.Log("Ceiling Stunned!");
            }
        }

        if (collision.collider.CompareTag("trap")) {//trap에 충돌하면 스턴상태 적용 및 움직임 변화
            isStunned = true;
            hitsound.Play();
            Debug.Log("Box Collided!");
        }
        if (isStunned) {
            if (isRight == 1) {
                FlipPlayer();
                rb.velocity = new Vector2(isRight * stunnedPower, -1f * stunnedPower);
            } else {
                FlipPlayer();
                rb.velocity = new Vector2(isRight * stunnedPower, -1f * stunnedPower);
            }
        }
        Debug.Log("Collision is made:" + collision.gameObject.name);
    }

    // Update is called once per frame
    void Update() {
        if (isStunned) {
            if (!stunmusic.isPlaying) {
                stunmusic.Play();
            }
            MovementState state = MovementState.stun;
            anim.SetInteger("state", (int)state);
        }
        if (!isStunned) {
            float dirX = Input.GetAxisRaw("Horizontal");
            if (!isWallJump)
                rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);
            if (IsGrounded()) {
                isWallJump = false;
            }
            if (IsWall() && !(IsGrounded())) {
                isWallJump = false;
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * wallingSpeed);
                if (Input.GetButtonDown("Jump")) {
                    jumpsound.Play();
                    CancelInvoke("FreezeX");
                    isWallJump = true;
                    Invoke("FreezeX", 1f);

                    if (isRight == 1) {
                        FlipPlayer();
                    } else {
                        FlipPlayer();
                    }
                    rb.velocity = new Vector2(isRight * walljumppower, 0.9f * walljumppower);
                }
            }
            if (Input.GetButtonDown("Jump") && IsGrounded()) {
                jumpsound.Play();
                rb.velocity = new Vector2(0, jumpPower);
            }
            UpdateAnimationUpdate(dirX);
        }
    }

    private bool IsGrounded() {
        //return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, jumbleGround);
        return Physics2D.BoxCast(transform.position, new Vector2(1, 1), 0, Vector2.down, groundCheckDistance, jumbleGround);

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
