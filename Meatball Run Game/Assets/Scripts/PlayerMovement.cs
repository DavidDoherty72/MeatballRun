using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //Movement
    public Rigidbody rb;
    public float forwardForce = 500f; //consant forward force 
    public float sidewaysForce = 500f; //sideways force 
    public float dash = 2000f;
    //public float MAX_SPEED = 2000f;

    //Jumping
    private float jumpSpeed = 5;
    private bool onGround = false;
    private int MAX_JUMP = 2;
    private int currentJump = 0; 

    //Shooting

    
        

    
    public void Start() 
    {
       rb = GetComponent<Rigidbody>();
    }


    
       

    void OnCollisionEnter(Collision collision)
    {
        onGround = true;
        currentJump = 0;
    }

    public void FixedUpdate ()
    {
        //add a Constant forward force   // adds force of 500 to Z axis
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);   
        


        if (Input.GetKey("d") ) //RIGHT
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a")) //LEFT
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("s")) //BACKWARDS
        {
            rb.AddForce(0, 0, -forwardForce * 2 * Time.deltaTime);
        }

        if (Input.GetKey("j")) //Dash
        {
            rb.AddForce(0, 0, dash * Time.deltaTime);
        }


        if (Input.GetKeyDown("space") && (onGround || MAX_JUMP > currentJump))
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            //player.GetComponent<Animator>().Play("Jump");
            onGround = false;
            currentJump++;
            
        }




        //checking if player falls 30ft off map
        if (rb.position.y < -30f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

     

    }




    //DO NOT TOUCH, ATTACHED TO SPEEDBOOST POWER UP
    public void SetforwardForce(float newSpeedAdjustment)
    {
            forwardForce += newSpeedAdjustment;
       
        //speed flash 
    }



}


