using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingCoins : MonoBehaviour
{
    public int coins;
    public Text coinText;
   

    // Start is called before the first frame update
   

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coins")
        {
            coins = coins + 1;
            Destroy(Col.gameObject);
        }

        if (Col.gameObject.tag == "2XCOINS")
        {
            coins = coins + 2;
            Destroy(Col.gameObject);
        }

        if (Col.gameObject.tag == "5XCOINS")
        {
            coins = coins + 5;
            Destroy(Col.gameObject);
        }

        if (Col.gameObject.tag == "10XCOINS")
        {
            coins = coins + 10;
            Destroy(Col.gameObject);
        }
    }

    public void Update()
    {
        coinText.text = coins.ToString("0");   

    }

}
