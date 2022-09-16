using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondTextUpdater : MonoBehaviour {

    int currentDiamond;
    [SerializeField] Text diamondText;
    
    private void Start()
    {
        StartCoroutine(GetDiamondCountAtStart());
    }
    IEnumerator GetDiamondCountAtStart()
    {
        yield return new WaitForSeconds(0.1f);
        currentDiamond = DiamondData.Instance.diamond;
        UpdateDiamondText();
    }

    public void UpdateDiamondText()
    {
        int totalDiamond = currentDiamond + ScoreManager.Instance.currentScore;

       // currentDiamond += ScoreManager.Instance.currentScore;
        diamondText.text = totalDiamond.ToString();
    }

}