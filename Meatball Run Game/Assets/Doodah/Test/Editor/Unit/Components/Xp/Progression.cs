using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class Progression {

  // AddExperience
  //
  [Test]
  [Description("Should succeed : add experience, no floor is defined")]
  public void AddExperience_PositiveValue_PositiveResult_NoFloor()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();

    progression.CapOnceMaxLevel = false;
    progression.AddExperience (50);

    var experience = progression.Experience;
    var level = progression.Level;

    Assert.AreEqual (50, experience);
    Assert.AreEqual (0, level);
  }

  [Test]
  [Description("Should succeed : remove experience, no floor is defined")]
  public void AddExperience_NegativeValue_PositiveResult_NoFloor()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();
    progression.CapOnceMaxLevel = false;
    progression.Experience = 100;
    progression.AddExperience (-25);

    var experience = progression.Experience;
    var level = progression.Level;

    Assert.AreEqual (75, experience);
    Assert.AreEqual (0, level);
  }

  [Test]
  [Description("Should succeed : remove experience causing to go in negative values, no floor is defined")]
  public void AddExperience_NegativeValue_NegativeResult_NoFloor()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();
    progression.CapOnceMaxLevel = false;
    progression.Experience = 5;
    progression.AddExperience (-115);

    var experience = progression.Experience;
    var level = progression.Level;

    Assert.AreEqual (-110, experience);
    Assert.AreEqual (0, level);
  }

  [Test]
  [Description("Should succeed : add experience, floor is exactly reached")]
  public void AddExperience_PositiveValue_FloorReached()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();
    progression.Floors.Add (100);
    progression.Experience = 5;
 
    progression.AddExperience (95);

    var experience = progression.Experience;
    var level = progression.Level;

    Assert.AreEqual (0, experience);
    Assert.AreEqual (1, level);
  }

  [Test]
  [Description("Should succeed : add experience, floor is over reached")]
  public void AddExperience_PositiveValue_FloorOverReached()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();
    progression.Floors.Add (100);

    progression.AddExperience (200);

    var experience = progression.Experience;
    var level = progression.Level;

    Assert.AreEqual (100, experience);
    Assert.AreEqual (1, level);
  }

  [Test]
  [Description("Should succeed : add experience, floor is reached multiples times")]
  public void AddExperience_PositiveValue_FloorReachedMultiplesTimes()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();
    progression.Floors.Add (100);
    progression.Floors.Add (100);
    progression.Floors.Add (100);

    progression.AddExperience (300);

    var experience = progression.Experience;
    var level = progression.Level;

    Assert.AreEqual (0, experience);
    Assert.AreEqual (3, level);
  }

  // GetFloor
  //
  [Test]
  [Description("Should succeed : get floor when null is defined")]
  public void GetFloor_NullDefined()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();
    progression.Floors = null;

    var floor = progression.GetFloor();

    Assert.AreEqual (-1, floor);
  }

  [Test]
  [Description("Should succeed : get floor when level is out of range")]
  public void GetFloor_OutOfRange()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();
    progression.Floors.Add (100);
    progression.Level = 5;

    var floor = progression.GetFloor();

    Assert.AreEqual (-1, floor);
  }

  [Test]
  [Description("Should succeed : get floor")]
  public void GetFloor()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();
    progression.Floors.Add (100);
    progression.Floors.Add (150);
    progression.Floors.Add (250);

    progression.Level = 1;

    var floor = progression.GetFloor();

    Assert.AreEqual (150, floor);
  }

  //IsFloorReached
  //
  [Test]
  [Description("Should succeed : check if floor reached, when no floor defined")]
  public void IsFloorReached_NoFloors()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();
    progression.Floors = null;

    progression.Experience = 150;

    var result = progression.IsFloorReached ();

    Assert.AreEqual (false, result);
  }

  [Test]
  [Description("Should succeed : check if floor reached, when level out of range")]
  public void IsFloorReached_FloorOutOfRange()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();
    progression.Floors.Add(100);

    progression.Level = 5;

    var result = progression.IsFloorReached ();

    Assert.AreEqual (false, result);
  }

  [Test]
  [Description("Should succeed : floor is reached")]
  public void IsFloorReached_FloorReached()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();
    progression.Experience = 200;

    progression.Floors.Add(100);

    var result = progression.IsFloorReached ();

    Assert.AreEqual (true, result);
  }

  [Test]
  [Description("Should succeed : floor is not reached")]
  public void IsFloorReached_FloorNotReached()
  {
    var gameObject = new GameObject();
    var progression = gameObject.AddComponent<Doodah.Components.Progression.Progression> ();
    progression.Experience = 90;

    progression.Floors.Add(100);

    var result = progression.IsFloorReached ();

    Assert.AreEqual (false, result);
  }
}
