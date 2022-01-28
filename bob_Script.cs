using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bob_Script : MonoBehaviour
{
    public GameObject EndOfGame;
    public Rigidbody2D rb;
    public Transform IsPaulHere;
    public LayerMask WhatIsPaul;

    public float checkRadius;
    public float bobSpeed;

    private bool IveBeenFound;

    // Start is called before the first frame update
    private Vector2 floatY;
    float originalY;

    public float floatStrength;

    void Start()
    {
        this.originalY = this.transform.position.y;

    }

    void Update()
    {
        floatY = transform.position;
        floatY.y = originalY + (Mathf.Sin(Time.time * bobSpeed) * floatStrength);
        transform.position = floatY;
    }

    public void DestroyGameObject(bool IsVPBeer)
    {
        Debug.Log("I have reached this in this");
        if (IsVPBeer)
        {
            EndOfGame.GetComponent<IsEnded>().FoundVPBeer();
        }
        else if (!IsVPBeer)
        {
            EndOfGame.GetComponent<IsEnded>().IncrementBeers();
        }
        Destroy(gameObject);


    }
}
