using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncomeUpManager : PowerUpManager
{
    [SerializeField] Text extraIncomeText;


    private void Start()
    {
        base.SetInfo();
        SetExtraIncomeText();
    }
    public int GetExtraIncomeAmount()
    {
        int level = powerUp.level;
        int extraIncome = powerUp.incomeList[level];
        return extraIncome;
    }

    public void SetExtraIncomeText()
    {
        int extrancome = GetExtraIncomeAmount();
        extraIncomeText.text = extrancome.ToString();
    }



}
