using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doodah.Components.Progression;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public GameObject MygameObject;
    public ExperienceCoins XP;
    public Text experienceText;
    public Text experienceText2;


    void Update()
    {
        if ( Input.GetKey ("l") ) 
        {
          
         IncrementXp(25);
               
        }

    }

     void OnTriggerEnter(Collider Col)
     {
        if (Col.gameObject.tag == "XP")
        {
            IncrementXp(25);
            Destroy(Col.gameObject);
            //Col.gameObject.SetActive(false);
        }
     }
    


    void IncrementXp(int value)
    {
        var progressionComponent = MygameObject.GetComponent<Progression>();
        progressionComponent.AddExperience(value);


        Debug.Log ("Level : " + progressionComponent.Level + " | Experience : " + progressionComponent.Experience);
        experienceText.text = ("Level : " + progressionComponent.Level);
        experienceText2.text = ("Experience : " + progressionComponent.Experience + "/Amount For Next Level");
    }

   


}
