using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speedChar = 10f;
    public float jumpForce = 10f;
    public LayerMask Ground;

    private float playerInput_X;
    private bool Orientation = true; // T = Right & F = Left


    private bool inAir = false;
    private float verticalVelocity;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    private bool TouchGround;
    

    private Rigidbody2D Rigidbody;
    private BoxCollider2D BoxCollider;
    private Animator Animator;



    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
        Animator = GetComponent<Animator>();

    }

    void Update()
    {
        _Movement();
        _Jump();

    }
    void _Movement()
    {
        //Movement in X
        playerInput_X = Input.GetAxis("Horizontal"); // -1 & 1 values
        verticalVelocity = Rigidbody.velocity.y;

        if (playerInput_X != 0)
        {
            Animator.SetBool("isRunning", true);
        }
        else
        {
            Animator.SetBool("isRunning", false);
        }

        Rigidbody.velocity = new Vector2(playerInput_X * speedChar, Rigidbody.velocity.y);
        TouchGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, Ground);


        //flip sprite
        _Orientation(playerInput_X);

        if (inAir)
        {
            Animator.SetBool("isJumping", true);
        }
        else
        {
            Animator.SetBool("isJumping", false);
        }

        if (!TouchGround)
        {
            Animator.SetBool("isFalling", true);
        }
        else
        {
            Animator.SetBool("isFalling", false);
        }



    }

    void _Orientation(float PlayerInput_X)
    {
        if ((Orientation && playerInput_X < 0) || (!Orientation && playerInput_X > 0))
        {
            Orientation = !Orientation;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }


    bool _OnGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(BoxCollider.bounds.center, new Vector2(BoxCollider.bounds.size.x, BoxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, Ground);
        return raycastHit.collider != null;
    }

    void _Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && _OnGround())
        {
            Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            inAir = true;
        }
        else
        {
            inAir = false;
        }
    }




}
