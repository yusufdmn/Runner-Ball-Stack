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
    public int currentScore;

    public void GetBallWorth(int factor)
    {
        currentScore += (ballWorth * factor);
        Debug.Log(currentScore);

    }

    public void MultiplyTheScore(int factor)
    {
        currentScore *= factor; 
    }

    public void CollectDiamond(int diamondWorth)
    {
        currentScore += diamondWorth;
        diamondTextUpdater.UpdateDiamondText();
    }

    public void FinishGame()
    {
        DiamondData.Instance.SaveDiamonds(currentScore);
    }

}