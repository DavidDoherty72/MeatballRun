using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public AdManager ads;
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public GameObject youDiedUI;
    

    public void CompleteLevel ()
    {
    completeLevelUI.SetActive(true);
    }
   
    public void youDied ()
    {
        youDiedUI.SetActive(true);
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
            youDied();
            Invoke("Restart", restartDelay);
            //Restart Game
            ads.PlayAd();
        }
    
    }
    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        youDiedUI.SetActive(false);
    }
       

}
