using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using UnityEngine.Internal;
using System.Collections;

public class TimeBasedExperience {
  // CheckTicks
  //
  [Test]
  [Description("Should succeed : add 0 experience cause no time passed")]
  public void CheckTicks_NoTimePassed()
  {
    var gameObject = new GameObject();
    var timeBasedExperience = gameObject.AddComponent<Doodah.Components.Progression.TimeBasedExperience> ();
    var progression = gameObject.GetComponent<Doodah.Components.Progression.Progression> ();
    timeBasedExperience.SetUpProgressionDelegate ();

    var currentTime = System.DateTime.UtcNow.Ticks / 10000000;

    progression.CapOnceMaxLevel = false;
    timeBasedExperience.PointsPerSecond = 100;
    timeBasedExperience.LastUpdate = currentTime;

    timeBasedExperience.CheckTicks ();

    var experience = progression.Experience;
    var level = progression.Level;

    Assert.AreEqual (0, experience);
  }

  [Test]
  [Description("Should succeed : add 200 experience, 2 sec passed, floor not reached")]
  public void CheckTicks_TimePassed_ExperienceWon_NoFloorReached()
  {
    var gameObject = new GameObject();
    var timeBasedExperience = gameObject.AddComponent<Doodah.Components.Progression.TimeBasedExperience> ();
    var progression = gameObject.GetComponent<Doodah.Components.Progression.Progression> ();
    timeBasedExperience.SetUpProgressionDelegate ();

    var currentTime = System.DateTime.UtcNow.Ticks / 10000000;

    progression.CapOnceMaxLevel = false;
    timeBasedExperience.PointsPerSecond = 100;
    timeBasedExperience.LastUpdate = currentTime - 2;

    timeBasedExperience.CheckTicks ();

    var experience = progression.Experience;
    var level = progression.Level;

    Assert.AreEqual (200, experience);
  }

  [Test]
  [Description("Should succeed : removed 200 experience, 2 sec roolback")]
  public void CheckTicks_TimeRoolback_ExperienceLost()
  {
    var gameObject = new GameObject();
    var timeBasedExperience = gameObject.AddComponent<Doodah.Components.Progression.TimeBasedExperience> ();
    var progression = gameObject.GetComponent<Doodah.Components.Progression.Progression> ();
    timeBasedExperience.SetUpProgressionDelegate ();

    var currentTime = System.DateTime.UtcNow.Ticks / 10000000;

    progression.CapOnceMaxLevel = false;
    progression.Experience = 500;
    timeBasedExperience.PointsPerSecond = 100;
    timeBasedExperience.LastUpdate = currentTime + 2;

    timeBasedExperience.CheckTicks ();

    var experience = progression.Experience;
    var level = progression.Level;

    Assert.AreEqual (300, experience);
  }
}
