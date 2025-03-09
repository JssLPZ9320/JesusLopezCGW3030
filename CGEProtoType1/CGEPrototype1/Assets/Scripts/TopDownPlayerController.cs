using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    //Adjust this value in the inspector to set players speed
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        //get the rigidbody2d component attached to the gameobject
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get input values for horizontal and vertical movement
        //use getaxis raw so the input is either 1,0,-1
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //normalize the movement vector to prevent faster diagonal movement 
        movement.Normalize();
    }

    void FixedUpdate()
    {
        //move the player using rigidbody2d in fixedupdate
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}
