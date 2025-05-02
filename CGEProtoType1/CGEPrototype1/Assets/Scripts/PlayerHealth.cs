using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    //variable to store health of player
    public int health = 100;

    //reference to health bar which must be set in the inspector
    public DisplayBar healthBar;

    //refernce to ridgided body
    private Rigidbody2D rb;

    private AudioSource playerAudio;
    public AudioClip playerHitSound;
   

    //knoickback force when player collides with enemy
    public float knockBack = 5f;

    //prefab to spawn when players dies must be set in the inpsector
    public GameObject PlayerDeathEffect;

    //bool to keep track if the player has been hit
    public static bool hitRecently = false;

    //time in seconds to recover from hit
    public float hitRecoveryTime = .2f;

    // Start is called before the first frame update
    void Start()
    {

        playerAudio = GetComponent<AudioSource>();

        //set rididbody
        rb = GetComponent<Rigidbody2D>();

        if(rb == null)
        {
            Debug.LogError("RididBody2D not found on Player");
        }

        healthBar.SetMaxValue(health);

        hitRecently = false;

        
    }

    public void Knockback(Vector3 enemyPosition)
    {
        if(hitRecently)
        {
            return;
        }

        hitRecently = true;

        if(gameObject.activeSelf)
        {
            StartCoroutine(RecoverFromHit());
        }

        

        Vector2 direction = transform.position - enemyPosition;

        direction.Normalize();

        direction.y = direction.y * .5f + .5f;

        rb.AddForce(direction * knockBack, ForceMode2D.Impulse);
    }

    IEnumerator RecoverFromHit()
    {
        yield return new WaitForSeconds(hitRecoveryTime);

        hitRecently = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.SetValue(health);

        //need a sound effect when player takes damage and need animation

        if(health <= 0)
        {
            Die();
        }
        else
        {
            playerAudio.PlayOneShot(playerHitSound);
        }
    }

    public void Die()
    {
        ScoreManager.gameOver = true;

        //instatinate the death effect at the players postion
        GameObject deathEffect = Instantiate(PlayerDeathEffect, transform.position, Quaternion.identity);

        
        Destroy(deathEffect, 2f);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    
}
