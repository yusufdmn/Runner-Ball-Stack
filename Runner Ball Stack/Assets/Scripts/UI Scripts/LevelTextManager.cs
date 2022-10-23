using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelTextManager : MonoBehaviour
{
    [SerializeField] Text levelText;

    public void SetLevelText(int level)
    {
        levelText.text = "Level " + level;
    }


}
