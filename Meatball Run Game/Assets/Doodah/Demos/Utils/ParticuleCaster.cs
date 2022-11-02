using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticuleCaster : MonoBehaviour {
  [Header("Particules")]
  public GameObject Particule;

  [Header("Time")]
  public float Duration = 5.0f;
  public float PopDelay = 0.2f;

  [Header("Range")]
  public float RangeMin = -1f;
  public float RangeMax = 1f;

  float nextPopDelay = 0;
  float endAt = 0;

  public void Cast()
  {
    endAt = Time.time + Duration;
  }

  void Update() {
    if ( Time.time < endAt && Time.time >= nextPopDelay)
    {
      nextPopDelay = Time.time + PopDelay;
      CreateParticule ();
    }
  }

  void CreateParticule() {
    var instance = GetParticule();

    if ( !instance )
    {
      return;
    }

    instance.transform.SetParent (this.transform);

    var position = new Vector3 (
      Random.Range (RangeMin, RangeMax),
      Random.Range (RangeMin, RangeMax),
      Random.Range (RangeMin, RangeMax));

    instance.transform.position = position;
  }

  GameObject GetParticule() {
    if ( !Particule )
    {
      Debug.LogWarning ("[PARTICULE CASTER] Required gameObject 'particule' not found : " + this);
      //Destroy (this.gameObject);
    }

    return Instantiate (Particule);
  }
}
