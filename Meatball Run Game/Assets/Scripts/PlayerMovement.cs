using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float dash = 1500f;

    
    

    //Jumping
    private float jumpSpeed = 5;
    private bool onGround = false;
    private int MAX_JUMP = 2;
    private int currentJump = 0;

    //Dashing
    private int MAX_DASH = 1;
    private int currentDash = 0;
    public Slider slider;
    public Image fill;
    public AudioClip dashSound;



    public void Start() 
    {
       rb = GetComponent<Rigidbody>();
       
    } 
     
    void OnCollisionEnter(Collision collision)
    {
        onGround = true;
        fill.gameObject.SetActive(true);
        currentJump = 0;
        currentDash = 0;
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
            rb.AddForce(0, 0, -forwardForce * 3 * Time.deltaTime);
        }

        if (Input.GetKey("w")) //FORWARDS
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if (Input.GetKeyDown("i") && (onGround || MAX_DASH > currentDash)) //DASH & DashCap
        {
            rb.AddForce(0, 0, dash * 3 * Time.deltaTime);
            onGround = false;
            currentDash++;
            fill.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(dashSound, transform.position);
           
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


