using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondTextUpdater : MonoBehaviour {

    int currentDiamond;
    [SerializeField] Text diamondText;
    
    private void Start()
    {
        
    }

    public void UpdateDiamondText()
    {
        currentDiamond += ScoreManager.Instance.currentScore;
        diamondText.text = currentDiamond.ToString();
    }

}
