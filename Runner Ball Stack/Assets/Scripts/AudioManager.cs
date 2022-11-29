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
        settingsSound.Play();
    }

    public void PlayWinSound()
    {
        winSound.Play();
    }
    public void PlayFailSound()
    {
        failSound.Play();
    }
}
