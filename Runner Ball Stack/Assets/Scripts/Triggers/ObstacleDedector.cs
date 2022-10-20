using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDedector : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
            explosion.Play();

    }
}
