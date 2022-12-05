using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSceneChange : MonoBehaviour
{

    

    //Use this for initialization
    void Start()
    {

    }

    //Play Global
    private static SoundSceneChange instance = null;
    public static SoundSceneChange Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

    }
    //Play Global End


    //Update is called once per frame
    void Update ()
    {

    }
}
