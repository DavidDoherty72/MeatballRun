using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Epilogue : MonoBehaviour
{
    // Start Coroutine 
    void Start()
    {
        StartCoroutine(CutsceneCoroutine());
    }

    IEnumerator CutsceneCoroutine()
    {
       

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(55);

        //After we have waited 55 seconds load levellist.
        SceneManager.LoadScene("Levellist");
      
    }
}
