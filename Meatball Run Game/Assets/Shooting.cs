using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //Shooting
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private GameObject objectToSpawn;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float forwardForce = 500f; //consant forward force 


    //Abilities
    public void FixedUpdate()
    {
    
        if (Input.GetKeyDown("k")) //SHOOT BOMB
        {
            SpawnGrenade();
           
        }

        if (Input.GetKey("l")) //SWORD
        {
            
        }

        if (Input.GetKey("j")) //LASER
        {
           
        }

        void SpawnGrenade()
        {
            Instantiate(objectToSpawn, transform.position + offset, Quaternion.identity);
            rb.AddForce(0, 0, forwardForce);
        }

    }

}
