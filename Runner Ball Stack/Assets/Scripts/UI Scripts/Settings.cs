using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] Sprite musicOff;
    [SerializeField] Sprite musicOn;
    [SerializeField] Sprite vibrationOff;
    [SerializeField] Sprite vibrationOn;
   
    [Space(2)]

    [Header("Images")]
    [SerializeField] Image music;
    [SerializeField] Image vibration;

    [Space(5)]

    [SerializeField] CanvasManager canvasManager;

    public static bool isVibrationOn;
    public static bool isMusicOn;

    private void Start()
    {
        isVibrationOn = true;
        isMusicOn = true;
    }
    
    public void SwitchVibration()
    {
        isVibrationOn = !isVibrationOn;
        if (isVibrationOn)
            vibration.sprite = vibrationOn;
        else
            vibration.sprite = vibrationOff;
    }
    public void SwitchMusic()
    {
        isMusicOn = !isMusicOn;
        if (isMusicOn)
            music.sprite = musicOn;
        else
            music.sprite = musicOff;
    }

    public void SettingsButton()
    {
        canvasManager.DisplaySettingsPopUp();
    }

}
