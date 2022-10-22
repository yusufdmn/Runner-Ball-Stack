using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int level;



    public void SetLevelInfo()
    {
        level = PlayerPrefs.GetInt("level", 1);

        if (SceneManager.GetActiveScene().buildIndex + 1 != level)
        {
            SceneManager.LoadScene(level - 1);
        }
    }
    public void PasstoNextLevel()
    {
        level++;
        PlayerPrefs.SetInt("level", level);
    }

}
