using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] ParticleSystem confetti1;
    [SerializeField] ParticleSystem confetti2;
    public IEnumerator LaunchEndOfTheGame()
    {
        StartCoroutine(PlayConfettis());
        yield return new WaitForSeconds(4f);
        GameManager.Instance.EndTheGame();
    }

    IEnumerator PlayConfettis()
    {
        yield return new WaitForSeconds(2f);
        confetti1.Play();
        yield return new WaitForSeconds(0.5f);
        confetti2.Play();
    }
}
