using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpForce = 10f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "walk";
    private string GROUND_TAG = "Ground";
    private float movementX;
    private bool isGrounded = false;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        PlayerMoveByKey();
        AnimatePlayer();
        AnimateJump();
    }

    void PlayerMoveByKey() {
        // Returns 1, -1 or 0
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveSpeed;
    }

    void AnimatePlayer() {
        if (movementX > 0) {
            // facing right
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } else if (movementX < 0) {
            // facing left
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        } else {
            // stop moving the player
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void AnimateJump() {
        // Jump on space press or up arrow
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded) {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == GROUND_TAG) {
            isGrounded = true;
            Debug.Log("Touching the Ground.");
        }
    }
}
