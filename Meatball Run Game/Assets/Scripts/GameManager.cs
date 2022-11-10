using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public AdManager ads;
    bool gameHasEnded = false;
    bool gameHasStarted = true;


    public float restartDelay = 1f;
    public float startGameDelay = 1f;



    public GameObject completeLevelUI;
    public void CompleteLevel ()
    {
    completeLevelUI.SetActive(true);
    }
   
    
    
    
    public void StartGame()
    {
        ads.ShowBanner();
        
    }

   // public void RewardedLife()
  // {
    //   ads.PlayRewardedAd(onRewardedAdSuccess);
   // }


    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
            //Restart Game
            ads.PlayAd();
        }
    
    }
    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   public void StartPause ()
   {
        if (gameHasStarted == false)
        {
            gameHasStarted = true;
            Debug.Log("Game is Waiting");
            Invoke("StartGame", restartDelay);
        }
   }


}
