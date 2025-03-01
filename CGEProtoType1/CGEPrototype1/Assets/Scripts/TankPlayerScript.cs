using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class TankPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    public float turnSpeed;

    public float horizontalInput;
    public float verticalInput;




    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right);

       // transform.Translate(Vector2.right * Time.deltaTime * speed);

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        //move player forward with vertical input
        transform.Translate(Vector2.right * Time.deltaTime * speed * verticalInput);

       // transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime * horizontalInput);

        //Rotate player with horixonal input but reverse the oration direction when moving

        if(verticalInput < 0)
        {
            transform.Rotate(Vector3.back, -turnSpeed * Time.deltaTime * horizontalInput);
        }
        else
        {
            transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);
        }

    }
}
