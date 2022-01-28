using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform WhereIsEdge;
    public Transform WhereIsWall;
    public LayerMask WhatIsGround;

    public float movementSpeed;
    public float checkRadius;

    private bool NotAboutToFallOff;
    private bool ThatsAWall;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movementSpeed < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(movementSpeed > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }


        NotAboutToFallOff = Physics2D.OverlapCircle(WhereIsEdge.position, checkRadius, WhatIsGround);
        ThatsAWall = Physics2D.OverlapCircle(WhereIsWall.position, checkRadius, WhatIsGround);


        if(ThatsAWall)
        {
            movementSpeed *= -1;
        }
        else if (!NotAboutToFallOff)
        {
            movementSpeed *= -1;
        }
        else
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }


    }
}
