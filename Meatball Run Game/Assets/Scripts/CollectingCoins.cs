using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingCoins : MonoBehaviour
{
    public int coins;
    public int coins2;
    public int coins5;
    public int coins10;
    public Text coinText;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coins")
        {
            coins = coins + 1;
            //Col.gameObject.SetActive(false);
            Destroy(Col.gameObject);
        }

        if (Col.gameObject.tag == "2XCOINS")
        {
            coins = coins + 2;
            //Debug.Log("Collected +2 COINS");
            //Col.gameObject.SetActive(false);
            Destroy(Col.gameObject);
        }

        if (Col.gameObject.tag == "5XCOINS")
        {
            coins = coins + 5;
            //Debug.Log("Collected +2 COINS");
            //Col.gameObject.SetActive(false);
            Destroy(Col.gameObject);
        }

        if (Col.gameObject.tag == "10XCOINS")
        {
            coins = coins + 10;
            //Debug.Log("Collected +2 COINS");
            //Col.gameObject.SetActive(false);
            Destroy(Col.gameObject);
        }
    }

    



    public void Update()
    {
        coinText.text = coins.ToString("0");
        //coinText.text = coins2.ToString("0");
       // coinText.text = coins5.ToString("0");
       // coinText.text = coins10.ToString("0");

    }




    // Update is called once per frame

}
