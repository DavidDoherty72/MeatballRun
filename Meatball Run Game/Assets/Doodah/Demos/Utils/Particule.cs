using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particule : MonoBehaviour {
  public float Speed = 0.7f;
  public float Duration = 2f;
  public Vector3 Movement = new Vector3 (0f, 1f, 0f);

  float endTime = 0;

  void Update () {
    if ( endTime == 0 )
    {
      endTime = Time.time + Duration;
    }

    if ( Time.time >= endTime )
    {
      Destroy (this.gameObject);
    }

    Vector3 deltaMovement = new Vector3 (
      Time.deltaTime * Movement.x * Speed,
      Time.deltaTime * Movement.y * Speed,
      Time.deltaTime * Movement.z * Speed);

    this.transform.Translate(deltaMovement);
  }
}
