using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform firePoint;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject firedProjectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        //destroy projectile are 3 seconds
        Destroy(firedProjectile, 3f);
    }
}
