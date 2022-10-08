using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level")]
public class LevelScriptable : ScriptableObject
{
    public bool[] obstacleAchievements;
    public bool GetIfUnlcokObstacle(int level)
    {
        return obstacleAchievements[level];
    }
}
