using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPShop : MonoBehaviour
{
    private string metalSkin = "com.daveDoherty.meatballAdventure.skinChange";
    public GameObject restorePurchaseBtn;

    private void Awake()
    {
        DisableRestorePurchaseBtn();
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == metalSkin)
        {
            Debug.Log("Add Metal Skin to Skin Change Menu");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of" + product.definition.id + "failed due to" + reason);
    }

    public void DisableRestorePurchaseBtn()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            restorePurchaseBtn.SetActive(false);
        }
    }
}
