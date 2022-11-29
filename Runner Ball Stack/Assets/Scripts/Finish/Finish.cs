using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] ParticleSystem confetti1;
    [SerializeField] ParticleSystem confetti2;

    public void DefineAudioManager()
    {
        audioManager = GameManager.Instance.audioManager;
    }

    public IEnumerator LaunchEndOfTheGame()
    {        
        StartCoroutine(PlayConfettis());
        yield return new WaitForSeconds(4f);
        GameManager.Instance.EndTheGame();
    }

    IEnumerator PlayConfettis()
    {
        yield return new WaitForSeconds(2f);
        audioManager.PlayWinSound();
        confetti1.Play();
        yield return new WaitForSeconds(0.5f);
        confetti2.Play();
    }
}
