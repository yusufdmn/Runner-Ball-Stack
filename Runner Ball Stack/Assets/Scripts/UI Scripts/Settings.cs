using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("On/Off Sprites")]
    [SerializeField] Sprite musicOff;
    [SerializeField] Sprite musicOn;
    [SerializeField] Sprite vibrationOff;
    [SerializeField] Sprite vibrationOn;
   
    [Space(2)]

    [Header("Setting Images")]
    [SerializeField] Image music;
    [SerializeField] Image vibration;

    [Space(5)]

    [SerializeField] CanvasManager canvasManager;

    public static bool isVibrationOn;
    public static bool isMusicOn;

    private void Start()
    {
        GetSavedSettings();
        SetSettingsSprites();
    }

    public void SwitchVibration()
    {
        isVibrationOn = !isVibrationOn;
        SetSettingsSprites();
        SaveSettings("vibration", isVibrationOn);
    }

    public void SwitchMusic()
    {
        isMusicOn = !isMusicOn;
        SetSettingsSprites();
        SaveSettings("music", isMusicOn);
    }

    private void SetSettingsSprites()
    {
        if (isVibrationOn)
            vibration.sprite = vibrationOn;
        else
            vibration.sprite = vibrationOff;
        if (isMusicOn)
            music.sprite = musicOn;
        else
            music.sprite = musicOff;
    }

    private int ConvertBoolToInt(bool boolValue)
    {
        if (boolValue)
            return 1;
        else
            return 0;
    }

    private bool ConvertIntToBool(int intValue)
    {
        if (intValue == 0)
            return false;
        else
            return true;
    }

    private void GetSavedSettings()
    {
        int intValueOfBool = PlayerPrefs.GetInt("vibration", 1);
        isVibrationOn = ConvertIntToBool(intValueOfBool);

        intValueOfBool = PlayerPrefs.GetInt("music", 1);
        isMusicOn = ConvertIntToBool(intValueOfBool);
    }

    private void SaveSettings(string key, bool boolValueOf›nt)
    {
        int settingValue = ConvertBoolToInt(boolValueOf›nt);
        PlayerPrefs.SetInt(key, settingValue);
    }


    public void SettingsButton()
    {
        canvasManager.DisplaySettingsPopUp();
    }
}
