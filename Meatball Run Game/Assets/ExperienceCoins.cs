using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceCoins : MonoBehaviour
{
    public int Experience;
    // public Text experienceText;



    public void GiveExperience(int val)
    {
     Experience = Experience + 1;

    }

    
        // void Update()
        //  {
        //     experienceText.text = xP.ToString("0");
        // }
    

    
}
