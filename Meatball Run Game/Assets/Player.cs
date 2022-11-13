using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doodah.Components.Progression;
using UnityEngine.UI;
using System;


public class Player : MonoBehaviour
{
    public Image playerCurrentSkin;
    public GameObject MygameObject;
  //  public ExperienceCoins XP;
    public Text experienceText;
    public Text experienceText2;
  


   
    //XP IS ATTACHED TO GAMEOBJECT
    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "XP")
        {
            IncrementXp(25);
            Destroy(Col.gameObject);
          
        }
    }


    //ACTUAL PROGRESSION SECTIONS
    void IncrementXp(int value)
    {
        var progressionComponent = MygameObject.GetComponent<Progression>();
        progressionComponent.AddExperience(value);

        //THIS IS WHERE LEVEL AND EXPERIENCE ARE ADDED TO UI
        Debug.Log("Level : " + progressionComponent.Level + " | Experience : " + progressionComponent.Experience);
        experienceText.text = ("Level : " + progressionComponent.Level);
        experienceText2.text = ("Experience : " + progressionComponent.Experience + "/Amount For Next Level");
    }

    
}
