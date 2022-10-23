using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleCoins : MonoBehaviour
{

    

    public int coins2;

    public Text coinText;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "2XCOINS")
        {
            coins2 = coins2 + 2;
            //Col.gameObject.SetActive(false);
            Destroy(Col.gameObject);
        }

    }



    public void Update()
    {
        coinText.text = coins2.ToString("0");


    }




    // Update is called once per frame

}
