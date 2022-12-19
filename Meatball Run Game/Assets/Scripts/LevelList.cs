using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelList : MonoBehaviour
{
    void Start()
    {
        //SoundSceneChange.Instance.gameObject.GetComponent<AudioSource>().UnPause();
    }


    public void Level1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 1");
    }
    public void Level2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 2");
    }
    public void Leve3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 3");
    }
    public void Level4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 4");
    }
    public void Level5()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 5");
    }
    public void Endless()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Endless");
    }
    public void Store()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Store");
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void Credits()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Credits");
    }
    public void Controls()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Controls");
    }

    public void PlayerProfile()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayerProfile");
    }

    public void Epilogue()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Epilogue");
    }
}
