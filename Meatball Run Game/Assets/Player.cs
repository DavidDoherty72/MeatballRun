using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doodah.Components.Progression;
using UnityEngine.UI;
using System;


public class Player : MonoBehaviour
{
    //public RatDamage ratDamage;
    public GameObject MygameObject;
    public Text levelText;
    public Text experienceText;
    
 
    //ACTUAL PROGRESSION SECTIONS
    public void IncrementXp(int value)
    {
        var progressionComponent = MygameObject.GetComponent<Progression>();
        progressionComponent.AddExperience(value);

        //THIS IS WHERE LEVEL AND EXPERIENCE ARE ADDED TO UI
        Debug.Log("Level : " + progressionComponent.Level + " | Experience : " + progressionComponent.Experience);
        levelText.text = ("Level : " + progressionComponent.Level);
        experienceText.text = ("Experience : " + progressionComponent.Experience);
    }

    
}
