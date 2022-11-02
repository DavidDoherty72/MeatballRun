using Doodah.Components.Progression;
using Doodah.Components.Appearance;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Doodah.Components.Progression
{
  [RequireComponent(typeof(Progression))]
  [RequireComponent(typeof(Skin))]

  public class ProgressionBasedSkin : MonoBehaviour {
    [Header("Skins")]
    public List<GameObject> Skins;

    private Progression ProgressionComponent;
    private Skin SkinComponent;

    void Start() {
      SetUpDelegate ();

      if ( Skins != null && Skins.Count > 0 )
      {
        AddSkin (Skins [0]);
      }
    }

    public void OnLevelUpdated(int previous, int current) {
      if ( Skins == null )
      {
        Debug.LogError("[SkinProgression] Required propertie 'Skins' is not defined", this);
        return;
      }

      if ( Skins.Count <= current )
      {
        Debug.LogWarning("[SkinProgression] Propertie 'Skins' does not defined value for index : " + current, this);
        return;
      }

      RemoveSkin ();
      AddSkin (Skins [current]);
    }

    public void RemoveSkin () {
      SkinComponent.RemoveSkin ();
    }

    public void AddSkin (GameObject skin) {
      SkinComponent.AddSkin (skin);
    }

    public void SetUpDelegate() {
      if ( ProgressionComponent == null )
      {
        ProgressionComponent = this.GetComponent<Progression> ();

        if ( ProgressionComponent == null )
        {
          Debug.LogError("[SKINPROGRESSION] Required component 'Progression' does not exist", this);
          return;
        }
      }

      if ( SkinComponent == null )
      {
        SkinComponent = this.GetComponent<Skin> ();

        if ( SkinComponent == null )
        {
          Debug.LogError("[SKINPROGRESSION] Required component 'Skin' does not exist", this);
          return;
        }
      }

      ProgressionComponent.EventLevelUpdated += OnLevelUpdated;
    }
  }
}
