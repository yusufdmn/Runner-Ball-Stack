using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockObstacleManager : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;    
    [SerializeField] LevelScriptable obstacleDataScriptable;
    [SerializeField] Image obstacleImage;    
    public bool shouldUnlockObstacle;
    
    public void SetUnlockObstacleInfo()
    {
        shouldUnlockObstacle = obstacleDataScriptable.GetIfUnlcokObstacle(levelManager.level);
        obstacleImage.sprite = obstacleDataScriptable.GetObstacleImage(levelManager.level);
    }

}
