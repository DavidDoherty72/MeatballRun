using Doodah.Components.Progression;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Doodah.Components.Appearance
{
  public class Skin : MonoBehaviour {
    [Header("Skins")]
    public GameObject DefaultSkin;
 
    [HideInInspector]
    public GameObject CurrentSkin;

    void Start() {
      if ( CurrentSkin )
      {
        AddSkin (CurrentSkin);
      }
      else
      {
        AddSkin (DefaultSkin);
      }
    }

    public void RemoveSkin () {
      if ( CurrentSkin )
      {
        CurrentSkin.SetActive (false);

        if ( Application.isEditor )
        {
          DestroyImmediate (CurrentSkin);
        }
        else
        {
          Destroy (CurrentSkin);
        }

        CurrentSkin = null;
      }
    }

    public void AddSkin (GameObject skin) {
      if (!skin || skin == null)
      {
        return;
      }

      var parentTransform = this.transform;
      var parentPos = parentTransform.position;

      GameObject newSkin = Instantiate(skin);
      newSkin.transform.SetParent (parentTransform);
      newSkin.transform.position = parentPos;
      newSkin.transform.localScale = parentTransform.localScale;

      if ( CurrentSkin )
      {
        RemoveSkin ();
      }

      CurrentSkin = newSkin;
    }
  }
}
