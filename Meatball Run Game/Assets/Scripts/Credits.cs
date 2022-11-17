using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void Endless()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Endless");
    }

    public void Levellist()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelList");
    }
}

