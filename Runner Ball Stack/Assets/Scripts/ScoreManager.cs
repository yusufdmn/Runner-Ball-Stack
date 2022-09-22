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

    [SerializeField] DiamondTextUpdater diamondTextUpdater;
    public int ballWorth;
  //  public int currentScore;

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

    public void SkipLevel()
    {
        diamondData.ResetLevelScore();
    }

    public void FinishLevelSuccessfully()
    {
        diamondData.SaveScore();
    }


    public IEnumerator AnimateToNewScore()
    {
        int preScore = diamondData.diamond;
        int newScore = diamondData.diamond + diamondData.levelScore;
        Debug.Log("Pre: " + preScore + "   new:" + newScore);
        int number = preScore;
        while (number <= newScore)
        {
            number += 12;
            diamondTextUpdater.diamondTextAtEnd.text = number.ToString();
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(2);
        GameManager.Instance.CompleteThelevel();
    }
}
