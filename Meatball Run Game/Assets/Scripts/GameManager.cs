using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
  
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
    
    



    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            youDied();
            Invoke("Restart", restartDelay);
            //Restart Game
         
        }
    
    }
    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        youDiedUI.SetActive(false);
    }
       

}
