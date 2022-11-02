using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Doodah.Utils;

namespace Doodah.Components.Progression
{
  [RequireComponent(typeof(Progression))]
  public class TimeBasedExperience : MonoBehaviour {
    [Header("Experience")]
    public float PointsPerSecond = 1;

    [Header("Timer")]
    public long LastUpdate = 0;

    [HideInInspector]
    public long CreationTimestamp = -1;
    private Progression ProgressionComponent;

    void Start () {
      SetUpProgressionDelegate ();
      ResetCreationTimestamp ();
    }

    private void ResetCreationTimestamp() {
      CreationTimestamp = LastUpdate = TimeKeeper.GetTimestamp ();
    }

    void Update () {
      if ( ProgressionComponent == null)
      {
        Debug.LogError("[TIMEBASEDEXPERIENCE] Required component 'Progression' does not exist", this);
        this.enabled = false;
        return;
      }

      CheckTicks ();
      CheckEnabled ();
    }

    public void CheckTicks() {
      if ( ProgressionComponent != null )
      {
        var currentTimestamp = TimeKeeper.GetTimestamp ();
        var elapsed = TimeKeeper.TimestampElapsed (LastUpdate, currentTimestamp);
        var points = elapsed * PointsPerSecond;

        LastUpdate = currentTimestamp;
        ProgressionComponent.AddExperience (points);
      }
    }

    public void CheckEnabled() {
      this.enabled = ProgressionComponent != null ?
        !ProgressionComponent.IsMaxLevel () :
        false;
    }

    public void SetUpProgressionDelegate() {
      if ( ProgressionComponent == null )
      {
        ProgressionComponent = this.GetComponent<Progression> ();
        ProgressionComponent.EventLevelUpdated += OnLevelUpdated;
      }
    }

    private void OnLevelUpdated(int previous, int current) {
      CheckEnabled ();
    }
  }
}