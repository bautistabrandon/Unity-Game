using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 500f;
    public bool canJump = true;


    // Update is called once per frame
    void FixedUpdate()
    {

 
        
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } else if (Input.GetKey("a")) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } else if (Input.GetKey("w") && canJump)
        { 
            rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
            canJump = false;
        }


        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if(rb.position.y > 2f)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }




  
    }

}
