using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 1f;
    private float movementX;
    private float movementY;
    private Rigidbody2D myRigidBody;
    private CapsuleCollider2D myBodyCollider;
    private BoxCollider2D myFeetCollider;
    private SpriteRenderer rend;
    private Animator myAnimator;
    private string TO_RUN = "ToRun";
    private string RUN_ANIMATION = "Run";
    private string JUMP_ANIMATION = "Jump";
    private bool isGrounded;
    private string GROUND_TAG = "Ground";
    private float gravityScale = 2f;
    private bool isAlive = true;
    private bool topDown = false;

    private void Awake() {
        myRigidBody = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeyboard() {
        if(Input.GetKeyDown(KeyCode.F)) {
            myAnimator.SetTrigger("Shift");
            if(myRigidBody.gravityScale == 0) {
                myRigidBody.gravityScale = gravityScale;
                topDown = false;
            } else {
                myRigidBody.gravityScale = 0;
                topDown = true;
            }
        }
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * runSpeed;
        if(topDown) {
            transform.position += new Vector3(0f, movementY, 0f) * Time.deltaTime * runSpeed;
        }
    }

    void AnimatePlayer() {
        if(movementX > 0 || movementY > 0) {
            myAnimator.SetBool(TO_RUN, true);
            myAnimator.SetBool(RUN_ANIMATION, true);
            rend.flipX = false;
        } else if(movementX < 0 || movementY < 0) {
            myAnimator.SetBool(TO_RUN, true);
            myAnimator.SetBool(RUN_ANIMATION, true);
            rend.flipX = true;
        } else {
            myAnimator.SetBool(RUN_ANIMATION, false);
            myAnimator.SetBool(TO_RUN, false);
        }
    }

    void PlayerJump() {
        if(!topDown) {
            if(Input.GetButtonDown("Jump") && isGrounded) {
                isGrounded = false;
                myRigidBody.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
                myAnimator.SetBool(JUMP_ANIMATION, true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag(GROUND_TAG) || collision.gameObject.CompareTag("Blocks")) {
            isGrounded = true;
            myAnimator.SetBool(JUMP_ANIMATION, false);
        }
    }
}
