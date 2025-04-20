using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    //Rigidbody component of the projectile 
    private Rigidbody2D rb;

    // speed of the projectile with a default value of 20
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody component
        rb = GetComponent<Rigidbody2D>();

        // set the colocity of the projectile to fire to the right at the speed
        rb.velocity = transform.right * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
