using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float initialForwardForce = 500f; //only applied once at start of program
    public float forwardForce = 500f; //consant forward force 
    public float sidewaysForce = 500f; //sideways force 
    public float downForce = 500f; // downward force on spacebar - opposite of jump 
    public float verticalForce = 500f; // upward force - jump
    public float alternatedownForce = 500f; // downward force applied to the jump button at the same time as jump



    

    
    public void Start() //Initial Forward Force
    {
        rb.AddForce(0, 0, initialForwardForce * Time.deltaTime);
    }

   


    public void FixedUpdate ()
    {
        //add a forward force
         


        rb.AddForce(0, 0, forwardForce * Time.deltaTime);   // adds force of 500 to Z axis
        


        if (Input.GetKey("d") ) //SIDEWAYS RIGHT
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a")) //SIDEWAYS LEFT
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("space")) //DROP
        {
            rb.AddForce(0, -downForce * Time.deltaTime, 0);
        }

        if (Input.GetKey("w")) //FORWARD
        {
            rb.AddForce(0, verticalForce * Time.deltaTime, 0);
        }

        if (Input.GetKey("w")) //FORWARD DOWNWARD
        {
            rb.AddForce(0, -alternatedownForce * Time.deltaTime, 0);
        }
        if (rb.position.y < -50f) //checking if player falls 10ft off map
        {
            FindObjectOfType<GameManager>().EndGame();
        }

     

    }

    public void SetforwardForce(float newSpeedAdjustment)
    {
            forwardForce += newSpeedAdjustment;
       
        //speed flash 
    }



}


