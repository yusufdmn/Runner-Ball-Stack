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
        StartCoroutine(UpdateDiamondTexts());
    }

    public IEnumerator UpdateDiamondTexts()
    {
        yield return new WaitForSeconds(0.1f);
        currentDiamond = diamondData.diamond;
        diamondTextAtEnd.text = currentDiamond.ToString();
        diamondText.text = currentDiamond.ToString();
    }

    public void UpdateTextWithCurrentScore()
    {
        int totalDiamond = currentDiamond + diamondData.levelScore;
        diamondText.text = totalDiamond.ToString();
        diamondTextAtEnd.text = totalDiamond.ToString();
    }


}