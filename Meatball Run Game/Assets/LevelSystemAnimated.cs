using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class LevelSystemAnimated  //MonoBehaviour
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;


    private LevelSystem levelSystem;
    private bool isAnimating;
    private float updateTimer;
    private float updateTimerMax;

    private int level;
    private int experience;
    private int experienceToNextLevel;



    public LevelSystemAnimated(LevelSystem levelSystem)
    {
        SetLevelSystem(levelSystem);
        updateTimerMax = .016f;
        FunctionUpdater.Create(() => Update());

       // Application.targetFrameRate = 64;
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        level = levelSystem.GetLevelNumber();
        experience = levelSystem.GetExperience();
        experienceToNextLevel = levelSystem.GetExperienceToNextLevel();

        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        isAnimating = true;
    }


    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        isAnimating = true;
    }

    private void Update()
    {
        if (isAnimating)
        {
            //Check if it is time to update
            updateTimer += Time.deltaTime;
            while (updateTimer > updateTimerMax)
            {//Time to update
                updateTimer -= updateTimerMax;
                UpdateAddExperience();
            }
        }
    }

    private void UpdateAddExperience() { 
            if (level < levelSystem.GetLevelNumber())
            { //local level under target level
                AddExperience();
            }
            else
            { //local level equals target level
                if (experience < levelSystem.GetExperience())
                {
                    AddExperience();
                } else
                {
                    isAnimating = false;
                }
            }
        
        
    }

    private void AddExperience()
    {
        experience++;
        if (experience >= experienceToNextLevel) {
         level++;
         experience = 0;
        if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
        }
         if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);


    }

    public int GetLevelNumber()
    {
        return level;

    }

    public float GetExperienceNormalized()
    {
        return (float)experience / experienceToNextLevel;
    }

    
}
