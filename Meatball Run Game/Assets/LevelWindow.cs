using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using CodeMonkey.Utils;

public class LevelWindow : MonoBehaviour
{
    public Text levelText;
    private Image experienceBarImage;
    private LevelSystem levelSystem;

    private void Awake()
    {
        levelText = transform.Find("levelText").GetComponent<Text>();
        experienceBarImage = transform.Find("experienceBar").Find("bar").GetComponent<Image>();

        //transform.Find()

    }
    private void SetExperienceBarSize(float experienceNormalized)
    {
        experienceBarImage.fillAmount = experienceNormalized;
    }
    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = "LEVEL" + (levelNumber + 1);
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        //set the level system object
        this.levelSystem = levelSystem;

        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());

        //Update the starting values
        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }
    //Experience Changed, Change bar size
    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
     SetExperienceBarSize(levelSystem.GetExperienceNormalized());
    }

    //Level Changed, Update text
    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        SetLevelNumber(levelSystem.GetLevelNumber());
    }



}
