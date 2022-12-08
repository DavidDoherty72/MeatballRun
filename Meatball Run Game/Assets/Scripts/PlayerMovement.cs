using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Movement
    [SerializeField]
    private Rigidbody rb;
    public float consistanceForce = 500f;
    [SerializeField]
    private float forwardForce = 500f; //consant forward force 
    [SerializeField]
    private float sidewaysForce = 500f; //sideways force 
    [SerializeField]
    private float dash = 500f;
    //public float MAX_SPEED = 2000f;

    //Jumping
    private float jumpSpeed = 5;
    private bool onGround = false;
    private int MAX_JUMP = 2;
    private int currentJump = 0;



    

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
          
        rb.AddForce(0, 0, consistanceForce * Time.deltaTime);    //add a Constant forward force 

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
            rb.AddForce(0, 0, -forwardForce * 4 * Time.deltaTime);
        }

        if (Input.GetKey("w")) //FORWARDS
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if (Input.GetKeyDown("i")) //DASH
        {
            rb.AddForce(0, 0, dash * 2 * Time.deltaTime);
            
           // GetComponent<ParticleSystem>().Play();
           // ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
           // em.enabled = true;
           
        }

        if (Input.GetKeyDown("space") && (onGround || MAX_JUMP > currentJump)) //Jump & JumpCap
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            onGround = false;
            currentJump++;
        }
                  
        //checking if player falls 70ft off map
        if (rb.position.y < -70f)
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
            

    public IEnumerator DashWait()
    {
        if (Input.GetKeyDown("i"))
        {
            yield return new WaitForSeconds(3f);
        }
            
    }
}


