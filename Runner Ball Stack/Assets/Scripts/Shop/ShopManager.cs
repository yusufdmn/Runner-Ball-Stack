using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] DiamondDataScriptable diamondData;
    [SerializeField] List<PowerUpUIObject> powerUpUIObjects;
    [SerializeField] DiamondTextUpdater diamondTextUpdater;

    public int GetDiamond()
    {
        return diamondData.diamond;
    }

    public void SetUpgradeBtnInteractivity()
    {
        int diamond = diamondData.diamond;
        foreach (PowerUpUIObject powerUpUI in powerUpUIObjects)
        {
            powerUpUI.SetButtonInteractivity();
        }
    }

    public void UpgradePowerUp(PowerUpScriptable powerUpScriptable, int price)
    {
        diamondData.diamond -= price;
        powerUpScriptable.Upgrade();
        StartCoroutine(diamondTextUpdater.UpdateDiamondTexts());
        SetUpgradeBtnInteractivity();
        diamondData.SaveScore();
    }

}