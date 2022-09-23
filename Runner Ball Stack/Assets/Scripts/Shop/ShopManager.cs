using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] DiamondDataScriptable diamondData;
    [SerializeField] List<PowerUpUIObject> powerUpUIObjects;
    [SerializeField] DiamondTextUpdater diamondTextUpdater;

    private void Start()
    {
        SetUpgradeBtnInteractivity();
    }

    public void SetUpgradeBtnInteractivity()
    {
        int diamond = diamondData.diamond;
        foreach (PowerUpUIObject powerUp in powerUpUIObjects)
        {
            powerUp.SetButtonInteractivity(diamond);
        }
    }

    public void UpgradePowerUp(PowerUpScriptable powerUpScriptable, int price)
    {
        diamondData.diamond -= price;
        powerUpScriptable.Upgrade();
        StartCoroutine(diamondTextUpdater.UpdateDiamondTexts());
        SetUpgradeBtnInteractivity();
    }

}