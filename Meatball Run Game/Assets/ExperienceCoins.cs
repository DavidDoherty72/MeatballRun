using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceCoins : MonoBehaviour
{
    public int xP;
   // public Text experienceText;

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "XP")
        {
            xP = xP + 25;
            Destroy(Col.gameObject);
            //Col.gameObject.SetActive(false);
        }

        // void Update()
        //  {
        //     experienceText.text = xP.ToString("0");
        // }
    }

    
}
