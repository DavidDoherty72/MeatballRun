using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatHealth : MonoBehaviour
{
    //Reference to Player for Experience gain
    public ExperienceCoins xP;

    //Animation
    public GameObject Rat;
    public Animation deathAnimation;
    //Health
    public int maxHealth = 100;
    public int curHealth = 100;
    public Healthbar healthBar;

    

    // Use this for initialization
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        AdjustCurrentHealth(0);
        
    }

    

    //UpdateHealth
    public void AdjustCurrentHealth(int adj)
    {
        curHealth += adj;

        if (curHealth < 0)
            curHealth = 0;
            

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (maxHealth < 1)
            maxHealth = 1;

        healthBar.SetHealth(curHealth);
        DeathEffects();
    }
    
    public void DeathEffects() //Plays Death animation and then destroys enemy
    {
        if (curHealth <= 0)
        {
            Rat.GetComponent<Animator>().Play("Death");
            Destroy(gameObject, 2f);
            Experience = Experience + 25;
        }

        
    }
}
