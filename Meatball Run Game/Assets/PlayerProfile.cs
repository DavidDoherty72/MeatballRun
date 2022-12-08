using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProfile : MonoBehaviour
{
    public void LevelList()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelList");
    }
}
