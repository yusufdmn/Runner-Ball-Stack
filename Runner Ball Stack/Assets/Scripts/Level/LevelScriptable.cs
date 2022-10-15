using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level")]
public class LevelScriptable : ScriptableObject
{
    public bool[] obstacleAchievements;
    public Sprite[] obstacleImages;
  //  public Dictionary<int, Sprite> obstacleDictionary;

    public bool GetIfUnlcokObstacle(int level)
    {
        return obstacleAchievements[level];
    }
    public Sprite GetObstacleImage(int level)
    {
        return obstacleImages[level];
    }
    
}
