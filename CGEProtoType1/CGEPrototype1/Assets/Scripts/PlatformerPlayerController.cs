using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{

    //player movement speed
    public float moveSpeed = 5f;

    //force applied when jumping
    public float jumpForce = 10f;

    //layer mask for detecting ground
    public LayerMask groundLayer;
    public Transform groundCheck;
    float groundCheckRadius = 0.2f;

    //keep track if we are on the ground
    private bool isGrounded; 

    //reference to rigidbody 2d component
    private Rigidbody2D rb;

    private float horizontalInput;

    public AudioClip jumpSound;

    private AudioSource playerAudio;

    public AudioClip scoreScound;

    private Animator animator;

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerAudio = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        //ensure groundcheck variable is assigned 
        if(groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //get input value for horizontal movement 
        horizontalInput = Input.GetAxis("Horizontal");

        //check for jump input
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    void FixedUpdate()
    {
        if(!PlayerHealth.hitRecently)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        }

        animator.SetFloat("xVelocityAbs", Mathf.Abs(rb.velocity.x));

        animator.SetFloat("yVelocityAbs", rb.velocity.y);


        //check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        animator.SetBool("onGround", isGrounded);

        //Ensure player is facing the direction of movement
        if(horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput <0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

   public void PlayCoinSound()
    {
        playerAudio.PlayOneShot(scoreScound, 1.0f);
    }

}
