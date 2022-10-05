using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelList : MonoBehaviour
{
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
    public void Level6()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 6");
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
}
