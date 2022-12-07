using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{
    public AdmobInterstitial admobInterstitial;
    public AdmobReward admobReward;
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        admobReward.InstantiateRewardedAds();
        admobInterstitial.RequestInterstitial();
    }

    public void CheckIfCanWatchAd()
    {
        if (admobInterstitial.interstitial.IsLoaded())
        {
            admobInterstitial.canShowAd = true;
        }
        else
        {
            admobInterstitial.canShowAd = false;
        }

        if (admobReward.hasRewardWatched)
        {
            admobInterstitial.canShowAd = false; 
        }
    }
}