using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int level;
    [SerializeField] LevelTextManager levelTextManager;
    [SerializeField] bool isTestActive;
    public void SetLevelInfo()
    {
        if (isTestActive)
            level = SceneManager.GetActiveScene().buildIndex + 1;
        else
            level = PlayerPrefs.GetInt("level", 1);

        if (SceneManager.GetActiveScene().buildIndex + 1 != level)
        {
          SceneManager.LoadScene(level - 1);
        }
        levelTextManager.SetLevelText(level);
    }
    public void PasstoNextLevel()
    {
        level++;
        PlayerPrefs.SetInt("level", level);
    }

}
