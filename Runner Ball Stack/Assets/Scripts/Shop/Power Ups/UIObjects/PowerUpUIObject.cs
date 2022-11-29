using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RDG;

public class PowerUpUIObject : MonoBehaviour
{
    [SerializeField] ShopManager shopManager;

    [SerializeField] PowerUpScriptable powerUp;
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] Text priceText;
    [SerializeField] Button upgradeButton;

    Animator animator;
    
    private void Start()
    {
        SetInfo();
        UpdateTexts();
        animator = gameObject.GetComponent<Animator>();
        SetButtonInteractivity();
    }
    public void SetInfo()
    {
        powerUp.SetInfo();
    }

    void UpdateTexts()
    {
        nameText.text = powerUp.name;
        levelText.text = "level " + powerUp.level.ToString();
        priceText.text = powerUp.price.ToString();
    }

    public void SetButtonInteractivity()
    {
        if (IsLevelMax())
        {
            FreezeUpdate();
            DeActivateButton();
            return;
        }

        int diamond = shopManager.GetDiamond();
        int price = powerUp.price;
        if (diamond < price)
            DeActivateButton();
    }

    private void DeActivateButton()
    {
        upgradeButton.interactable = false;
        animator.enabled = false;
    }

    public virtual void Upgrade()
    {
        if(Settings.isVibrationOn)
            Vibration.Vibrate(35);

        int price = powerUp.price;
        
        shopManager.UpgradePowerUp(powerUp, price);
        UpdateTexts();

        if (IsLevelMax())
            FreezeUpdate();
    }

    public bool IsLevelMax()
    {
        if (powerUp.level >= powerUp.maxLevel)  
            return true;
        else 
            return false;
    }

    public void FreezeUpdate()
    {
        levelText.text = "MAX";
        priceText.text = "FULL";
    }
}
