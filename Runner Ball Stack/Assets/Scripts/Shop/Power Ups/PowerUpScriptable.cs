using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PowerUp")]
public class PowerUpScriptable : ScriptableObject
{
    public string name;
    public int price;
    public int level;
    public int[] priceList;
    public int[] incomeList;
    

    public void Upgrade()
    {
        level++;
        price = priceList[level];
        SaveInfo();
    }

    public void SaveInfo()
    {
        PlayerPrefs.SetInt(name, level);
    }
    public void SetInfo()
    {
        level = PlayerPrefs.GetInt(name, 1);
        price = priceList[level];
    }

}