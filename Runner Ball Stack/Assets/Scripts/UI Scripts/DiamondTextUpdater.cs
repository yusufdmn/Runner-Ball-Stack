using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondTextUpdater : MonoBehaviour {

    int currentDiamond;
    public Text diamondText;
    public Text diamondTextAtEnd;
    [SerializeField] DiamondDataScriptable diamondData;
    private void Start()
    {
        StartCoroutine(GetDiamondCountAtStart());
    }
    IEnumerator GetDiamondCountAtStart()
    {
        yield return new WaitForSeconds(0.1f);
        currentDiamond = diamondData.diamond;
        diamondTextAtEnd.text = currentDiamond.ToString();
        UpdateDiamondText();
    }

    public void UpdateDiamondText()
    {
        int totalDiamond = currentDiamond + diamondData.levelScore;

       // currentDiamond += ScoreManager.Instance.currentScore;
        diamondText.text = totalDiamond.ToString();
    }


}