using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiamondData")]
public class DiamondDataScriptable : ScriptableObject
{
    public int diamond;
    public int levelScore;

    public void SaveScore()
    {
        diamond += levelScore;
        levelScore = 0;
        PlayerPrefs.SetInt("diamond", diamond); 
    }
    public void ResetLevelScore()
    {
        levelScore = 0;
    }

    public void SetDiamondData()
    {
        diamond = PlayerPrefs.GetInt("diamond", 250);
    }
}