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
   

    //Damage is Applied
    void OnTriggerEnter(Collider Col)
    {
    if (Col.gameObject.tag == "Enemy")
        {
            health.AdjustCurrentHealth(-25);
            Rat.GetComponent<Animator>().Play("GetHit");
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            

        }
    
    }    
}
