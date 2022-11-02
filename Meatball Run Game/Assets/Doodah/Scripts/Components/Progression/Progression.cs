using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace Doodah.Components.Progression
{
  public class Progression : MonoBehaviour
  {
    public delegate void ValueUpdated (int previous, int current);
    public event ValueUpdated EventLevelUpdated;
    public event ValueUpdated EventExperienceUpdated;

    [Header("Level")]
    public int Min = 0;
    public int Max = 10;

    [Header("Experience")]
    public bool CapOnceMaxLevel = true;
    public List<uint> Floors = new List<uint> ();

    private int level = 0;
    private float experience = 0;

    public int Level {
      get { return level; }
      set
      {
        value = Mathf.Clamp (value, Min, Max);

        if ( value == Level )
        {
          return;
        }

        var previous = Level;
        level = value;

        if ( EventLevelUpdated != null )
        {
          EventLevelUpdated (previous, value);
        }
      }
    }

    public float Experience {
      get { return experience; }
      set
      {
        if ( value == experience)
        {
          return;
        }

        var previous = Experience;
        experience = value;

        TriggerExperienceFloor ();

        if ( EventExperienceUpdated != null )
        {
          EventExperienceUpdated (Mathf.FloorToInt(previous), Mathf.FloorToInt(value));
        }
      }
    }

    public void AddExperience(float value, bool capToMaxLevel = true) {
      if ( value == 0 || ShouldStopExperienceGain())
      {
        return;
      }

      Experience += value;
    }

    public bool ShouldStopExperienceGain()
    {
      return (Level >= Floors.Count && CapOnceMaxLevel);
    }

    public void AddLevel(int value) {
      if ( value == 0 )
      {
        return;
      }

      Level += value;
    }

    public int GetFloor() {
      if ( Floors == null )
      {
        Debug.LogWarning("[EXPERIENCE] Variable 'Floors' is not defined", this);
        return -1;
      }

      if ( Floors.Count <= Level )
      {
        Debug.LogWarning("[EXPERIENCE] Variable 'Floors' does not define value for level : " + Level, this);
        return -1;
      }

      return int.Parse(Floors[Level].ToString());
    }

    public void TriggerExperienceFloor() {
      if ( IsFloorReached () )
      {
        var floor = GetFloor ();
        Level += 1;
        Experience -= floor;
      }
    }

    public bool IsFloorReached() {
      var floor = GetFloor ();
      return floor >= 0 && Experience >= floor;
    }

    public bool IsMaxLevel() {
      return Level == Max;
    }
  }
}
