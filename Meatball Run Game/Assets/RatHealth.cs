using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatHealth : MonoBehaviour
{
    //Reference to Player for Experience gain
    //public ExperienceCoins xP;
    public Player player;

    //Animation reference
    public GameObject Rat;

    
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
            DeathEffects();
        

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (maxHealth < 1)
            maxHealth = 1;

        healthBar.SetHealth(curHealth);
       
    }

    //Plays Death animation and then destroys enemy
    public void DeathEffects() 
    {
        if (curHealth <= 0)
        {
            //xP.GiveExperience();
            player.IncrementXp(1);
             Rat.GetComponent<Animator>().Play("Death");
            Destroy(gameObject, 2f);

        }

        
    }
}
