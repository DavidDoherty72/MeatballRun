using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    
        // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    //FixedUpdate is called every physics update
    private void FixedUpdate()
    {
    
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 4);
    }

 

}


