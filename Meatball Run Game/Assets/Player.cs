using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doodah.Components.Progression;
using UnityEngine.UI;
using System;


public class Player : MonoBehaviour
{
    
    public GameObject MygameObject;
    public Text levelText;
    public Text experienceText;
  


   
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
        levelText.text = ("Level : " + progressionComponent.Level);
        experienceText.text = ("Experience : " + progressionComponent.Experience + "/Amount For Next Level");
    }

    
}
