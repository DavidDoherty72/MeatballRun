using Doodah.Components.Progression;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Doodah.Demo.ProgressionRegular
{
  public class Context : MonoBehaviour {
    public GameObject Character;
    public int XpPerPress = 10;

    public Text UiLevel;
    public Text UiExperience;

    GameObject characterInstance;
    Progression characterProgressionComponent;

    void Start() {
      characterInstance = Instantiate (Character);
      characterInstance.transform.parent = this.transform;

      characterProgressionComponent = characterInstance.GetComponent<Progression> ();
    }

    void Update() {
      if ( Input.GetKeyUp ("space") )
      {
        IncrementXp ();
      }

      UpdateUi ();
    }

    void IncrementXp() {
      characterProgressionComponent.AddExperience(XpPerPress);
    }

    void UpdateUi() {
      if ( UiLevel )
      {
        UiLevel.text = "Level : " + characterProgressionComponent.Level.ToString ();
      }

      if ( UiExperience )
      {
        UiExperience.text = "Experience : " + Mathf.FloorToInt(characterProgressionComponent.Experience).ToString();
      }
    }
  }
}
