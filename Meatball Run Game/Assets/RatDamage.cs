using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatDamage : MonoBehaviour
{
    //Reference to Rat Health
    public RatHealth health;
    public GameObject Rat;
   
    //Effects
    [SerializeField]
    private AudioClip hitSound;
    public Animation clipGetHit;


    void OnTriggerEnter(Collider Col)
    {
    if (Col.gameObject.tag == "Enemy")
        {
            health.AdjustCurrentHealth(-25);
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            Rat.GetComponent<Animator>().Play("GetHit");

        }
    
    }    
}
