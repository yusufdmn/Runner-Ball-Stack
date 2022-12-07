using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobInterstitial : MonoBehaviour
{
    public InterstitialAd interstitial;
    public bool canShowAd;

    public void RequestInterstitial()
    {
       string adUnitId = "ca-app-pub-2309141602496848/8046976055";
       //  string adUnitId = "ca-app-pub-3940256099942544/1033173712";  //SAMPLE

        this.interstitial = new InterstitialAd(adUnitId);

        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void ShowAd()
    {
        canShowAd = false;
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            GameManager.Instance.CompleteThelevel();
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        canShowAd = true;
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        canShowAd = false;
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        GameManager.Instance.CompleteThelevel();
        interstitial.Destroy();
    }
}
