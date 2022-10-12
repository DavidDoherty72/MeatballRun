using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
    }
    public void LevelList()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelList");
    }
    public void Endless()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Endless");
    }
}

