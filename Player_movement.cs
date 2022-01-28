using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public Transform WhereAreFeet;
    public LayerMask WhatIsGround;

    public float movementSpeed;
    public float jumpForce;
    public float checkRadius;

    private float playerInput;
    private float Speed;

    private bool isGrounded;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-3f, 23f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(WhereAreFeet.position, checkRadius, WhatIsGround);

        if (!isGrounded)
        {
            animator.SetBool("Jumping", true);
        }
        else if(isGrounded)
        {
            animator.SetBool("Jumping", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }

        if(WhereAreFeet.position.y < 10)
        {
            SceneManager.LoadScene(3);
        }

        if (Input.GetKeyDown("r"))
        {
            transform.position = new Vector3(-3, 23, 0);
        }


    }

    void FixedUpdate()
    {
        playerInput = Input.GetAxisRaw("Horizontal");
        Speed = movementSpeed * playerInput;

        rb.velocity = new Vector2(Speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(Speed));

        if(playerInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(playerInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }

    public void Launch()
    {
        rb.velocity = Vector2.up * 47;
    }
}
