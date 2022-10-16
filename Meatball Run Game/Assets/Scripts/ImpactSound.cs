using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{

    public AudioSource impactSound;
    public AudioSource impactSound2;
    public AudioSource impactSound3;
    public AudioSource impactSound4;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1)
        {
        
            impactSound.PlayOneShot(impactSound.clip);

            impactSound2.PlayOneShot(impactSound2.clip);

            impactSound3.PlayOneShot(impactSound3.clip);

            impactSound4.PlayOneShot(impactSound4.clip);
        }
    }
}