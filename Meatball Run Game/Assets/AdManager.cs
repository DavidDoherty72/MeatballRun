using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    string gameID = "4962622";
#else
    string gameID = "4962623";
#endif

    Action onRewardedAdSuccess;


    // Start is called before the first frame update
    public void Start()
    {
        Advertisement.Initialize(gameID);
        Advertisement.AddListener(this);
        ShowBanner();
    }



    // Update is called once per frame
    public void PlayAd()
    {
        if (Advertisement.IsReady("Interstitial_iOS"))
        {
            Advertisement.Show("Interstitial_iOS");
        }
    }

    public void PlayRewardedAd()
    {
       // onRewardedAdSuccess = onSuccess; 
        if (Advertisement.IsReady("Rewarded_iOS")){
            Advertisement.Show("Rewarded_iOS");
        }
        else{
            Debug.Log("Rewared Ad is Not Ready!");
        }
    }
    public void ShowBanner()
    {
        if (Advertisement.IsReady("Banner_iOS"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show("Banner_iOS");
        }
        else{
            StartCoroutine(RepeatShowBanner());
        }

    }
    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        ShowBanner();
    }

    public void OnUnityAdsReady(string placementId){
        Debug.Log("Rewared Ad is Ready!");
    }
    public void OnUnityAdsDidError(string message){
        Debug.Log("Error" + message);
    }
    public void OnUnityAdsDidStart(string placementId){
        Debug.Log("Video Started");
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) {
        if (placementId == "Rewarded_iOS" && showResult == ShowResult.Finished){
            Debug.Log("Player Is Rewarded");
        }
    }

}
