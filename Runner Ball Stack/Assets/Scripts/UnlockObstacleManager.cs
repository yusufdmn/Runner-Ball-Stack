using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockObstacleManager : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    public bool shouldUnlockObstacle;
    [SerializeField] LevelScriptable levelScriptable;

    public void SetUnlockObstacleInfo()
    {
        shouldUnlockObstacle = levelScriptable.GetIfUnlcokObstacle(levelManager.level - 1);
    }

}