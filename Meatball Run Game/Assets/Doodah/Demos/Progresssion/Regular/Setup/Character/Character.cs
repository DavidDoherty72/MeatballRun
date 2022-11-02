using Doodah.Components;
using Doodah.Components.Progression;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Doodah.Demo.ProgressionRegular
{
  [RequireComponent(typeof(ProgressionBasedSkin))]
  public class Character : MonoBehaviour {
    [Header("Particules")]
    public ParticuleCaster ParticuleCasterForXp;
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

      if ( !ParticuleCasterForXp )
      {
        Debug.LogWarning ("[CHARACTER] Required component 'ParticuleCasterForLvl' is not defined");
        return;
      }

      ParticuleCasterForXp.Cast();
    }

    void OnLevelUpdated(int previous, int current)
    {
      if ( previous >= current )
      {
        return;
      }

      if ( !ParticuleCasterForXp )
      {
        Debug.LogWarning ("[CHARACTER] Required component 'ParticuleCasterForLvl' is not defined");
        return;
      }

      ParticuleCasterForLvl.Cast();
    }
  }
}
