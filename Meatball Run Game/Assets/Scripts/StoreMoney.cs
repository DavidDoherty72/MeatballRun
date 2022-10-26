using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoreMoney : MonoBehaviour
{
    public int coins;
    public Text totalUI;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelList()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelList");
    }
    public void GenerateCoins()
        {
        coins = coins + 1;
        totalUI.text = coins.ToString("0");
    }
}
