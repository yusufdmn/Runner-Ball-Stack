using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpObject : MonoBehaviour
{
    [SerializeField] ShopManager shopManager;

    [SerializeField] PowerUpScriptable powerUp;
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] Text priceText;
    [SerializeField] Button upgradeButton;

    private void Start()
    {
        UpdateTexts();
    }

    void UpdateTexts()
    {
        nameText.text = powerUp.name;
        levelText.text = "level " + powerUp.level.ToString();
        priceText.text = powerUp.price.ToString();
    }

    public void SetButtonInteractivity(int diamond)
    {
        int price = powerUp.price;
        if (diamond < price)
            upgradeButton.interactable = false;
    }

    public void Upgrade()
    {
        int price = powerUp.price;
        shopManager.UpgradePowerUp(powerUp, price);
        UpdateTexts();
    }

}
