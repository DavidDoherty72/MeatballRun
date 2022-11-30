using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //Shooting
    [SerializeField]
    private GameObject grenade; //GRENADE 
    [SerializeField]
    private Rigidbody grenadeRigidbody; //MAKES THE EXPLOSION DROP 
    [SerializeField]
    private Vector3 offset; //EXPLOSION DISTANCE FROM PLAYER
    [SerializeField]
    private GameObject grenadeEffect; //PARTICLE EFFECT
    [SerializeField]
    private AudioClip grenadeSound; //AUDIO SOURCE

   

    //Abilities
    public void FixedUpdate()
    {
       
        if (Input.GetKeyDown("k")) //SHOOT Gernade
        {
            SpawnGrenade();
            
        }
    }

    void SpawnGrenade()
    {
        GameObject clone = Instantiate(grenade, transform.position + offset, Quaternion.identity);
        SpawnGrenadeEffects();

        Destroy(clone, 1.0f);
    }

    void SpawnGrenadeEffects()
    {
        Instantiate(grenadeEffect, transform.position + offset, Quaternion.identity);
        AudioSource.PlayClipAtPoint(grenadeSound, transform.position);

    }
}
