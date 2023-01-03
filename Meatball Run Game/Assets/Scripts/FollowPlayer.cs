using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    

    void Start()
    {
        //Start the Camera field of view at 60
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        
        if (Input.GetKeyDown("i"))
        {

           // Debug.Log("Dashed");

        }
    }

   public IEnumerator DashFOVReset()
    {
        if (Input.GetKeyDown("i"))
        {
            yield return new WaitForSeconds(2);
            Debug.Log("DashWait");
        }

    }
}
      