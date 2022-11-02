using Doodah.Components.Progression;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Doodah.Demo.ProgressionTimeBased
{
  [RequireComponent(typeof(ProgressionBasedSkin))]
  public class Seed : MonoBehaviour {
    [Header("Particules")]
    public ParticuleCaster ParticuleCasterForLvl;

    private Progression ComponentProgressions;

    void Start()
    {
      ComponentProgressions = this.gameObject.GetComponent<Progression> ();

      ComponentProgressions.EventExperienceUpdated += OnExperienceUpdated;
      ComponentProgressions.EventLevelUpdated += OnLevelUpdated;
    }

    void OnExperienceUpdated(int previous, int current)
    {
      if ( previous >= current )
      {
        return;
      }
    }

    void OnLevelUpdated(int previous, int current)
    {
      if ( previous >= current )
      {
        return;
      }

      ParticuleCasterForLvl.Cast();
    }
  }
}
