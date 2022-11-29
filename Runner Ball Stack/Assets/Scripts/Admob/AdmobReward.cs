using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;

public class AdmobReward : MonoBehaviour
{
    [SerializeField] EarnButton earnButton; 

    private RewardedAd rewardedExtraCoin;
    private RewardedAd rewardedSkipLevel;

    public void InstantiateRewardedAds()
    {
        rewardedExtraCoin = CreateAndLoadRewardedAd();
        rewardedSkipLevel = CreateAndLoadRewardedAd();
        SetRewardedAdEvents();
    }

    public void ShowRewardedExtraCoinAd()
    {
        if (this.rewardedExtraCoin.IsLoaded())
        {
            this.rewardedExtraCoin.Show();
        }
    }

    public void ShowRewardedSkipLevelAd()
    {
        if (this.rewardedSkipLevel.IsLoaded())
        {
            this.rewardedSkipLevel.Show();
        }
    }

    public RewardedAd CreateAndLoadRewardedAd()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
         string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
         string dUnitId = "unexpected_platform";
#endif

        RewardedAd rewardedAd = new RewardedAd(adUnitId);

        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
        return rewardedAd;
    }

    public void SetRewardedAdEvents()
    {
        this.rewardedExtraCoin.OnUserEarnedReward += HandleUserEarnedRewardExtra;
        this.rewardedExtraCoin.OnAdClosed += HandleRewardedAdClosedExtra;


        this.rewardedSkipLevel.OnUserEarnedReward += HandleUserEarnedRewardSkip;
        this.rewardedSkipLevel.OnAdClosed += HandleRewardedAdClosedSkip;
    }

    public void HandleRewardedAdClosedExtra(object sender, EventArgs args)
    {
        rewardedExtraCoin.Destroy();
    }

    public void HandleUserEarnedRewardExtra(object sender, Reward args)
    {
        earnButton.GiveExtraDiamond();
    }


    public void HandleRewardedAdClosedSkip(object sender, EventArgs args)
    {
    }

    public void HandleUserEarnedRewardSkip(object sender, Reward args)
    {
        GameManager.Instance.SkipLevel();
    }
}