using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    #region Singleton Definiton
    private static ScoreManager instance;       // ******Definition of Singleton********
    public static ScoreManager Instance { get { return instance; } }
    private void Awake()
    {
        diamondData.SetDiamondData();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField] UnlockObstacleManager unlockObstacleManager;
    bool shouldUnlockObstacle;
    
    [SerializeField] DiamondTextUpdater diamondTextUpdater;
    public int ballWorth;

    [SerializeField] CanvasManager canvasManager;
    [SerializeField] IncomeUpManager incomeUpManager;

    [SerializeField] DiamondDataScriptable diamondData;
    public void GetBallWorthASScore(int factor)
    {
        diamondData.levelScore += (ballWorth * factor);
    }

    public void MultiplyTheScore(int factor)
    {
        diamondData.levelScore *= factor; 
    }

    public void CollectDiamond(int diamondWorth)
    {
        diamondData.levelScore += diamondWorth;
        diamondTextUpdater.UpdateTextWithCurrentScore();
    }

    public void ResetLevelScore()
    {
        diamondData.ResetLevelScore();
    }

    public void FinishLevelSuccessfully()
    {
        diamondData.SaveScore();
    }

    public IEnumerator AnimateToNewScore()
    {
        AddExtraIncome();
        int preScore = diamondData.diamond;
        int newScore = diamondData.diamond + diamondData.levelScore;
        int number = preScore;

        int animationSpeed = 5 + ((newScore - preScore) / 50);
        while (number <= newScore)
        {
            number += animationSpeed;
            diamondTextUpdater.diamondTextAtEnd.text = number.ToString();
            yield return new WaitForSeconds(0.001f);
        }
        diamondTextUpdater.diamondTextAtEnd.text = (diamondData.diamond + diamondData.levelScore).ToString();
        //StartCoroutine(AnimateDiamondText());
        yield return new WaitForSeconds(1);

        shouldUnlockObstacle = unlockObstacleManager.shouldUnlockObstacle;
        if (shouldUnlockObstacle)
            canvasManager.DisplayUnlockObstaclePanel();
        else
            GameManager.Instance.CompleteThelevel();
    }

    IEnumerator AnimateDiamondText()
    {
        int preScore = diamondData.diamond;
        int newScore = diamondData.diamond + diamondData.levelScore;
        int number = preScore;

        int animationSpeed = 5 + ((newScore - preScore) / 150);
        while (number <= newScore)
        {
            number += animationSpeed;
            diamondTextUpdater.diamondTextAtEnd.text = number.ToString();
            yield return new WaitForSeconds(0.001f);
        }
    }

    public void AddExtraIncome()
    {
        int extraIncome = incomeUpManager.GetExtraIncomeAmount();
        diamondData.levelScore += extraIncome;
    }
}
