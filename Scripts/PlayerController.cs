using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speedChar = 5f;
    public float jumpForce = 5f;

    private float playerInput_X;
    private bool Orientation = true; // T = Right & F = Left

    private Rigidbody2D Rigidbody;



    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();

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
        Rigidbody.velocity = new Vector2(playerInput_X * speedChar, Rigidbody.velocity.y);

        //flip sprite
        _Orientation(playerInput_X);

    }

    void _Orientation(float PlayerInput_X)
    {
        if ((Orientation && playerInput_X < 0) || (!Orientation && playerInput_X > 0))
        {
            Orientation = !Orientation;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    void _Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }




}
