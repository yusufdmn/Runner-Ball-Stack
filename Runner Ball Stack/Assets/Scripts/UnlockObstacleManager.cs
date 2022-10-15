using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockObstacleManager : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    public bool shouldUnlockObstacle;
    [SerializeField] LevelScriptable obstacleDataScriptable;
    [SerializeField] Image obstacleImage;
    public void SetUnlockObstacleInfo()
    {
        shouldUnlockObstacle = obstacleDataScriptable.GetIfUnlcokObstacle(levelManager.level - 1);
        obstacleImage.sprite = obstacleDataScriptable.GetObstacleImage(levelManager.level-1);
    }

}