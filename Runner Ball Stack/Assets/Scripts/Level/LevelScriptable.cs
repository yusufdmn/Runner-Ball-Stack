using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level")]
public class LevelScriptable : ScriptableObject
{
    public bool[] obstacleAchievements;
    public Sprite[] obstacleImages;

    public bool GetIfUnlcokObstacle(int level)
    {
        if(level < 25)
            return obstacleAchievements[level];
        return false;
    }
    public Sprite GetObstacleImage(int level)
    {
        if(level < 25)
            return obstacleImages[level];
        return null;
    }
    
}
