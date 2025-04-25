using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //enemy heatlh
    public int health = 100;

    //a prefab to spawn when the enemy dies
    public GameObject deathEffect;

    //reference to the health bar
    private DisplayBar HealthBar;

    public void TakeDamage(int damage)
    {
        // subtract the damage dealth from health 
        health -= damage;

        HealthBar.SetValue(health);

        if(health <= 0)
        {
            Die();
        }
    }

    private void Start()
    {
        HealthBar = GetComponentInChildren<DisplayBar>();

        if (HealthBar == null)
        {
            Debug.LogError("HealthBar (DisplayBar script) not found");
            return;
        }

        HealthBar.SetMaxValue(health);
    }

    // Update is called once per frame
    void Die()
    {
        //Spawn death effect 
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
        
    }
}
