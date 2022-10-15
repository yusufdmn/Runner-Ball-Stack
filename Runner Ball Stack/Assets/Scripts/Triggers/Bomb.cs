using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
   // ParticleSystem explodeEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FirstBall"))
        {
       // explodeEffect.Play();
        StartCoroutine(DisableYourself());
        StackManager.Instance.stackedBalls[0].GetComponent<FirstBallMoveForward>().SetSpeed(7);
        }

    }

    IEnumerator DisableYourself()
    {
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
    }
}
