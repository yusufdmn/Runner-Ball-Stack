using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreMultiplier : MonoBehaviour
{
    [SerializeField] int multiplierFactor;

    public void GetBallWorthASscore()
    {
        ScoreManager.Instance.GetBallWorthASScore(multiplierFactor);
    }
}
