using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatHealth : MonoBehaviour
{

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
    }
}
