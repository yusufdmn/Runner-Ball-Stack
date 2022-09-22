using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarnButton : MonoBehaviour
{
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

    [SerializeField] DiamondDataScriptable diamondData;

    private void Update()
    {
        if (isEarnButtonClicked)
            return;

        FindEarnedWheelValue();
        earnText.text = (earnedWheelScore * diamondData.levelScore).ToString();
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
        StartCoroutine(uITweenAnimation.Animate());
        
        isEarnButtonClicked = true;
        adWheelArrow.enabled = false;

        ScoreManager.Instance.MultiplyTheScore(earnedWheelScore);
       // GameManager.Instance.CompleteThelevel();
    }

}