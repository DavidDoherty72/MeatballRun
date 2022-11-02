using Doodah.Components.Progression;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Doodah.Demo.ProgressionTimeBased
{
  public class Context : MonoBehaviour {
    public GameObject Seed;

    public Text UiLevel;
    public Text UiExperience;

    GameObject seedInstance;
    Progression seedProgressionComponent;

    void Start() {
      seedInstance = Instantiate (Seed);
      seedInstance.transform.parent = this.transform;

      seedProgressionComponent = seedInstance.GetComponent<Progression> ();
    }

    void Update() {
      UpdateUi ();
    }

    void UpdateUi() {
      if ( UiLevel )
      {
        UiLevel.text = "Level : " + seedProgressionComponent.Level.ToString ();
      }

      if ( UiExperience )
      {
        UiExperience.text = "Experience : " + Mathf.FloorToInt(seedProgressionComponent.Experience).ToString();
      }
    }
  }
}
