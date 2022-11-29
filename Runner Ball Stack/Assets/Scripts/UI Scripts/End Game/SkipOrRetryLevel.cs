using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipOrRetryLevel : MonoBehaviour
{
    [SerializeField] AdManager adManager;

    public void SkipLevel()
    {
        adManager.admobReward.ShowRewardedSkipLevelAd();
    }
    public void RetryLevel()
    {
        GameManager.Instance.RetryLevel();
    }
}
