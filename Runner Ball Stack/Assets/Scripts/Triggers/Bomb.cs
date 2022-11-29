using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] ParticleSystem explodeEffect;
    GameObject explosionObj;

    private void Start()
    {
        explosionObj = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FirstBall"))
        {
        StartCoroutine(DisableYourself());
        if(StackManager.Instance.stackedBalls.Count > 0)
            StackManager.Instance.stackedBalls[0].GetComponent<FirstBallMoveForward>().SetSpeed(8);
        }
        else if (other.CompareTag("ball"))
        {
            StartCoroutine(DisableYourself());
        }
    }

    IEnumerator DisableYourself()
    {
        explosionObj.transform.parent = null;
        Destroy(explosionObj, 4);
//        transform.GetChild(0).parent = null;
        explodeEffect.Play();
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
    }
}
