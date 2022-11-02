using UnityEngine;
using UnityEditor;
using NUnit.Framework;

using System.Collections.Generic;

public class Skin {

  // AddSkin
  //
  [Test]
  [Description("Should succeed, add skin if CurrentSkin is null")]
  public void WhenNoCurrentSkin() {
    var gameObject = new GameObject ();
    var skinA = new GameObject ("skinA");

    var skinComponent = gameObject.AddComponent<Doodah.Components.Appearance.Skin> ();

    skinComponent.AddSkin (skinA);
    Assert.AreEqual ("skinA(Clone)", gameObject.transform.GetChild(0).name);
    Assert.AreEqual (1, gameObject.transform.childCount);
  }

  [Test]
  [Description("Should succeed, add skin if CurrentSkin exist")]
  public void WhenCurrentSkinExist() {
    var gameObject = new GameObject ();
    var skinA = new GameObject ("skinA");

    var skinComponent = gameObject.AddComponent<Doodah.Components.Appearance.Skin> ();
    skinComponent.CurrentSkin = new GameObject ("OriginalSkin");

    skinComponent.AddSkin (skinA);
    Assert.AreEqual ("skinA(Clone)", gameObject.transform.GetChild(0).name);
    Assert.AreEqual (1, gameObject.transform.childCount);
  }
}
