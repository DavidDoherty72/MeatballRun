using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class LevelWindow : MonoBehaviour
{
    public Text levelText;
    private Image experienceBarImage;
    private LevelSystem levelSystem;
    private LevelSystemAnimated levelSystemAnimated;

    private void Awake()
    {
        levelText = transform.Find("levelText").GetComponent<Text>();
        experienceBarImage = transform.Find("experienceBar").Find("bar").GetComponent<Image>();

        transform.Find("experience5Btn").GetComponent<Button_UI>();//.ClickFunc = () => levelSystem.AddExperience(5); 
        transform.Find("experience50Btn").GetComponent<Button_UI>();//.ClickFunc = () => levelSystem.AddExperience(50);
        transform.Find("experience500Btn").GetComponent<Button_UI>();//.ClickFunc = () => levelSystem.AddExperience(500);

    }
    //In Place of .ClickFun (.ClickFunc does not work)
    public void Add5XP() 
    {
        levelSystem.AddExperience(5);
    }

    //In Place of .ClickFunc
    public void Add50XP()
    {
        levelSystem.AddExperience(50);
    }
    //In Place of .ClickFunc
    public void Add500XP()
    {
        levelSystem.AddExperience(500);
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
        this.levelSystem = levelSystem;
    }

    public void SetLevelSystemAnimated(LevelSystemAnimated levelSystemAnimated)
    {
        //set the LevelSystemAnimated object
        this.levelSystemAnimated = levelSystemAnimated;

        SetLevelNumber(levelSystemAnimated.GetLevelNumber());
        SetExperienceBarSize(levelSystemAnimated.GetExperienceNormalized());

        //Update the starting values
        levelSystemAnimated.OnExperienceChanged += LevelSystemAnimated_OnExperienceChanged;
        levelSystemAnimated.OnLevelChanged += LevelSystemAnimated_OnLevelChanged;
    }
    //Experience Changed, Change bar size
    private void LevelSystemAnimated_OnExperienceChanged(object sender, System.EventArgs e)
    {
     SetExperienceBarSize(levelSystemAnimated.GetExperienceNormalized());
    }

    //Level Changed, Update text
    private void LevelSystemAnimated_OnLevelChanged(object sender, System.EventArgs e)
    {
        SetLevelNumber(levelSystemAnimated.GetLevelNumber());
    }



}
