using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondTextUpdater : TextUpdater
{
    int currentDiamond;
    private void Start()
    {
        currentDiamond = base.GetIntFromData(base.nameOfTextData);
        base.textUI.text = currentDiamond.ToString();
    }

}
