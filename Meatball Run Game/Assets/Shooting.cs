using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //Ammo Capacity
    public int bullets;
    public int maxBullets = 5;
    public int minBullets = 0;
    public Text bulletsText;
    
    
   
    public void Start()
    {
        bullets = maxBullets;
    }

    //Abilities
    public void FixedUpdate()
    {
       
        if (Input.GetKeyDown("k")) //SHOOT Grenade
        {
            SpawnGrenade(1);
            bullets = bullets - 1;

            if (bullets <= minBullets)
            {
                Reload();
            }
        }

        if (Input.GetKeyDown("r")) //RELOAD
        {
            Reload();
            
        }

        bulletsText.text = bullets.ToString("AMMO:" + "0");
    }

    void SpawnGrenade(int amount)
    {
        GameObject clone = Instantiate(grenade, transform.position + offset, Quaternion.identity);
        SpawnGrenadeEffects();

        Destroy(clone, .2f);

    }

    void SpawnGrenadeEffects()
    {
        Instantiate(grenadeEffect, transform.position + offset, Quaternion.identity);
        AudioSource.PlayClipAtPoint(grenadeSound, transform.position);
        
    }

    void Reload()
    {
        bullets = maxBullets;
       
    }

}
