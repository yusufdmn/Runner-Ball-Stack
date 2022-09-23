using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplierCircle : ScoreMultiplier
{
    [SerializeField] ParticleSystem starParticle;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PassedLine")
        {
            base.GetBallWorthASscore();
            starParticle.Play();
        }
    }

}
