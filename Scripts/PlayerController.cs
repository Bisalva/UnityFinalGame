using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    public Transform shootPoint;
    public GameObject arrowPrefab;

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


    private Rigidbody2D RB;
    private BoxCollider2D BoxCollider;
    private Animator Animator;



    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
        Animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (GameManager.Instance._getAlive() == true)
        {
            _Movement();
            _Jump();
            _Shoot();
        }
        else
        {
            _Death();

        }

    }
    void _Movement()
    {
        //Movement in X
        playerInput_X = Input.GetAxis("Horizontal"); // -1 & 1 values
        verticalVelocity = RB.velocity.y;

        if (playerInput_X != 0)
        {
            Animator.SetBool("isRunning", true);
        }
        else
        {
            Animator.SetBool("isRunning", false);
        }

        RB.velocity = new Vector2(playerInput_X * speedChar, RB.velocity.y);
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
            transform.Rotate(0, 180, 0);
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
            RB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            inAir = true;
        }
        else
        {
            inAir = false;
        }
    }

    void _Shoot()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Animator.SetTrigger("isShooting");
            GameManager.Instance._shootArrow();

            Instantiate(arrowPrefab, shootPoint.position,transform.rotation);

        }
    }

    void _Death()
    {
        if (GameManager.Instance._getAlive() == false)
        {
            Animator.SetTrigger("isDead");
            BoxCollider.size = new Vector2(0.21f, 0.10f);
            gameObject.layer = LayerMask.NameToLayer("Dead");
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && GameManager.Instance._IsTakingDamage() == true)
        {
            GameManager.Instance._TakingDamageStatusChange();
        }
    }


}
