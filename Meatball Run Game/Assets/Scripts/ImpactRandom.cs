using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactRandom : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;



    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1)
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.PlayOneShot(source.clip);
        }
    }
}
