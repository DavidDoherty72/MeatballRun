using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingCoins : MonoBehaviour
{
    public int coins;
    public Text coinText;

    [SerializeField]
    private AudioClip collectSound;
    // Start is called before the first frame update

    //Coins Attached to GameObject
    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coins")
        {
            coins = coins + 1;
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            Destroy(Col.gameObject);
        }

    }

    public void Update()
    {
        coinText.text = coins.ToString("0");   

    }

}
