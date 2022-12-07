using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarnButton : MonoBehaviour
{
    [SerializeField] AdManager adManager;

    [SerializeField]  GameObject earnButtonObj;
    [SerializeField] GameObject noThanksButtonObj;

    [SerializeField] UITweenAnimation uITweenAnimation;

    [SerializeField] AdWheelArrow adWheelArrow;
    [SerializeField] RectTransform wheelArrowTransform;
    float z;
    [SerializeField] int maxWheelScore;
    [SerializeField] int midWheelScore;
    [SerializeField] int minWheelScore;
    int earnedWheelScore;

    [SerializeField] Text earnText;

    bool isEarnButtonClicked;

    [SerializeField] Button earnButton;
    [SerializeField] Button noButton;


    [SerializeField] DiamondDataScriptable diamondData;

    private void Update()
    {
        if (isEarnButtonClicked)
            return;

        FindEarnedWheelValue();
        earnText.text = "Get " + (earnedWheelScore * diamondData.levelScore).ToString();
    }

    void FindEarnedWheelValue() {
        z = wheelArrowTransform.localRotation.z;

        if (Mathf.Abs(z) < Mathf.Abs(0.15f))
            earnedWheelScore = maxWheelScore;
        else if (Mathf.Abs(z) < Mathf.Abs(0.45f))
            earnedWheelScore = midWheelScore;
        else
            earnedWheelScore = minWheelScore;
    }

    public void EarnWithAd()
    {
        adManager.admobReward.ShowRewardedExtraCoinAd();
    }

    public void GiveExtraDiamond()
    {
        ScoreManager.Instance.MultiplyTheScore(earnedWheelScore);
        StartCoroutine(uITweenAnimation.Animate());

        DisableReClick();
        //adManager.admobReward.ShowRewardedExtraCoinAd();
    }

    private void DisableReClick()
    {
        noButton.enabled = false;
        earnButton.enabled = false;
        isEarnButtonClicked = true;
        adWheelArrow.enabled = false;
        noThanksButtonObj.SetActive(false);
        earnButtonObj.SetActive(false);
    }

}