using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{

    public Text textUI;
    public string nameOfTextData;

    public string GetStringFromData(string nameOfStringData)
    {
        string currentText = PlayerPrefs.GetString(nameOfTextData);
        return currentText;
    }
    public int GetIntFromData(string nameOfStringData)
    {
        int currentValue = PlayerPrefs.GetInt(nameOfTextData);
        return currentValue;
    }

    public void UpdateText(string updatedText)
    {
        textUI.text = updatedText;
    }


}
