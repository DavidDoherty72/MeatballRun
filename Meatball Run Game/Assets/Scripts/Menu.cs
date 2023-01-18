using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void StartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayerProfile()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayerProfile");
    }

    public void Achievements()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Achievements");
    }
}
