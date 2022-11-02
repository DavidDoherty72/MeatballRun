using UnityEngine;
using UnityEditor;
using NUnit.Framework;

using System.Collections.Generic;

public class ProgressionBasedSkin {

  // OnLevelUpdated
  //
  [Test]
  [Description("Should succeed, and update skin based on level")]
  public void OnLevelUpdated_ChangeBasedOnLevel() {
    var gameObject = new GameObject ();
    var skinA = new GameObject ("skinA");
    var skinB = new GameObject ("skinB");
    var skinC = new GameObject ("skinC");

    var progressionBasedSkinComponent = gameObject.AddComponent<Doodah.Components.Progression.ProgressionBasedSkin> ();
    var skinComponent = gameObject.AddComponent<Doodah.Components.Appearance.Skin> ();
    progressionBasedSkinComponent.SetUpDelegate ();

    progressionBasedSkinComponent.Skins = new List<GameObject> ();
    progressionBasedSkinComponent.Skins.Add(skinA);
    progressionBasedSkinComponent.Skins.Add(skinB);
    progressionBasedSkinComponent.Skins.Add(skinC);

    progressionBasedSkinComponent.OnLevelUpdated (0, 2);

    Assert.AreEqual ("skinC(Clone)", gameObject.transform.GetChild(0).name);
  }

  [Test]
  [Description("Should succeed, and do nothing as level is out of possible skin ranges")]
  public void OnLevelUpdated_NoChanges_LevelOutOfRange() {
    var gameObject = new GameObject ();
    var skinA = new GameObject ("skinA");
    var skinB = new GameObject ("skinB");
    var skinC = new GameObject ("skinC");

    var progressionBasedSkinComponent = gameObject.AddComponent<Doodah.Components.Progression.ProgressionBasedSkin> ();
    var skinComponent = gameObject.AddComponent<Doodah.Components.Appearance.Skin> ();
    progressionBasedSkinComponent.SetUpDelegate ();

    progressionBasedSkinComponent.Skins = new List<GameObject> ();
    progressionBasedSkinComponent.Skins.Add(skinA);
    progressionBasedSkinComponent.Skins.Add(skinB);
    progressionBasedSkinComponent.Skins.Add(skinC);

    progressionBasedSkinComponent.OnLevelUpdated (0, 7);

    Assert.AreEqual (0, gameObject.transform.childCount);
  }
}
