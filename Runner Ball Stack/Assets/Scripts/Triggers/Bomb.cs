using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] ParticleSystem explodeEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FirstBall"))
        {
        transform.GetChild(0).parent = null;
        explodeEffect.Play();
        StartCoroutine(DisableYourself());
        if(StackManager.Instance.stackedBalls.Count > 0)
            StackManager.Instance.stackedBalls[0].GetComponent<FirstBallMoveForward>().SetSpeed(7);
        }
    }

    IEnumerator DisableYourself()
    {
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
    }
}
