using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource settingsSound;
    [SerializeField] AudioSource winSound;
    [SerializeField] AudioSource failSound;


    public void PlaySettingSound()
    {
        if (Settings.isMusicOn)
            settingsSound.Play();
    }

    public void PlayWinSound()
    {
        if (Settings.isMusicOn)
            winSound.Play();
    }
    public void PlayFailSound()
    {
        if(Settings.isMusicOn)
            failSound.Play();
    }
}
