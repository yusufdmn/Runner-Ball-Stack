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

    public int ballWorth;
    public int currentScore;
    //public int multiplierFactor = 1;

    public void GetBallWorth(int factor)
    {
        currentScore += ballWorth * factor;
    }

    public void MultiplyTheScore(int factor)
    {
        currentScore *= factor;
    }

}
