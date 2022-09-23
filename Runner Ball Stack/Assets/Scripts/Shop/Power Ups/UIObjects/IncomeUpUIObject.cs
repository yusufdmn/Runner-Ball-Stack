using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeUpUIObject : PowerUpUIObject
{
    [SerializeField] IncomeUpManager incomeUpManager;

    public override void Upgrade()
    {
        base.Upgrade();
        incomeUpManager.SetExtraIncomeText();
    }
}
