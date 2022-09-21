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
        diamondTextUpdater.UpdateDiamondText();
    }

    public void SkipLevel()
    {
        diamondData.ResetLevelScore();
    }

    public void FinishLevelSuccessfully()
    {
        //DiamondData.Instance.SaveDiamonds(currentScore);
        diamondData.SaveScore();
    }

}