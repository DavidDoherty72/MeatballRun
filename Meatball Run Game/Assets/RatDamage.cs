using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatDamage : MonoBehaviour
{
    public RatHealth health;
   // public ExperienceCoins xP;
     
     
    void OnTriggerEnter(Collider Col)
    {
    if (Col.gameObject.tag == "Enemy")
        {
            health.AdjustCurrentHealth(-25);
           
        }
    
    }    
}
