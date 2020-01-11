using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmove : MonoBehaviour {
    public float movespeed = 1f;
    Rigidbody2D myRigidbody;
    Collider2D bodycol;
    public string platmove;
    public LayerMask surface;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        bodycol = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (platmove == "Vertical")
        {
            myRigidbody.velocity = new Vector2(0f, movespeed);
        }
        else if (platmove == "Horizontal")
        {
            myRigidbody.velocity = new Vector2(movespeed, 0f);
        }

        //if (bodycol.IsTouchingLayers(surface))
        //{
            //movespeed *= -1;
        //}
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bodycol.IsTouchingLayers(surface))
        {
           movespeed *= -1;
        }
        
    }
}
