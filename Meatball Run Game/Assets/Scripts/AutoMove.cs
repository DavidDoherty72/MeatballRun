using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{

    public Rigidbody rb;
    public float initialForwardForce = 500f; //only applied once at start of program
    public float forwardForce = 50f; //consant forward force 

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0, 0, initialForwardForce * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);   // adds force of 500 to Z axis  
    }
}
