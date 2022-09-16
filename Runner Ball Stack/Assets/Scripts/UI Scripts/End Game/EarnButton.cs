using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarnButton : MonoBehaviour
{
    [SerializeField] AdWheelArrow adWheelArrow;
    [SerializeField] RectTransform wheelArrowTransform;
    float z;
    [SerializeField] int maxWheelScore;
    [SerializeField] int midWheelScore;
    [SerializeField] int minWheelScore;
    ScoreManager scoreManager;
    int earnedWheelScore;

    [SerializeField] Text earnText;

    bool isEarnButtonClicked;
    private void Start()
    {
        scoreManager = ScoreManager.Instance;
    }

    private void Update()
    {
        if (isEarnButtonClicked)
            return;

        z = wheelArrowTransform.localRotation.z;

        if (Mathf.Abs(z) < Mathf.Abs(0.15f))
            earnedWheelScore = maxWheelScore;
        else if (Mathf.Abs(z) < Mathf.Abs(0.45f))
            earnedWheelScore = midWheelScore;
        else
            earnedWheelScore = minWheelScore;

        earnText.text = (earnedWheelScore * scoreManager.currentScore).ToString();
    }

    public void EarnWithAd()
    {
        isEarnButtonClicked = true;
        adWheelArrow.enabled = false;

        scoreManager.MultiplyTheScore(earnedWheelScore);
        GameManager.Instance.PassToNextLevel();
    }

}