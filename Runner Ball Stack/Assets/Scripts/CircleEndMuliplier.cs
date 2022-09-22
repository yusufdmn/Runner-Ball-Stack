using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEndMuliplier : ScoreMultiplier
{
    [SerializeField] ParticleSystem startEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PassedLine")
        {
            base.GetBallWorthASscore();
            other.tag = "Untagged";
            startEffect.Play();
        }
    }
}
