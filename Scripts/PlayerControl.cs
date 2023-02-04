using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Rigidbody2D playerRB;
    Animator playerAnimator;

    public float moveSpeed = 1f;
    public float jumpSpeed = 1f, jumpFreq = 1f, nextJumpTime;

    bool facingRight = true;

    public bool isGrounded = false;
    public Transform GroundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    void Awake()
    {
 
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        onGroundCheck();

        if(playerRB.velocity.x < 0 && facingRight){
            FlipFace();
        }
        else if(playerRB.velocity.x > 0 && !facingRight){
            FlipFace();
        }

        if(Input.GetAxis("Vertical") > 0 && isGrounded  && (nextJumpTime < Time.timeSinceLevelLoad)){
            nextJumpTime = Time.timeSinceLevelLoad + jumpFreq;
            Jump();
           }
    }

    void FixedUpdate()
    {   

    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed , playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    void FlipFace(){
        facingRight = !facingRight;
        Vector3 templocalScale = transform.localScale;
        templocalScale.x *= -1;
        transform.localScale = templocalScale;
    }

    void Jump(){
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
        if(Door.activeScene != 0)
        {
            SoundManager.playSound("jumpsound");
        }
    }

    void onGroundCheck(){
        isGrounded = Physics2D.OverlapCircle(GroundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}
