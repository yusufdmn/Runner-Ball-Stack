using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreMultiplierTriggers : MonoBehaviour
{
    [SerializeField] int multiplierFactor;
    Transform child;

    Vector3 bigScale;
    Vector3 normalScale;

    private void Start()
    {
        normalScale = new Vector3(1, 1, 1);
        bigScale = new Vector3(1.3f, 1.3f, 1.3f);
        child = transform.GetChild(0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball" || other.tag == "FirstBall")
        {
            other.tag = "Untagged";
            other.gameObject.SetActive(false);
            ScoreManager.Instance.GetBallWorth(multiplierFactor);
            child.DOScale(bigScale, 0.4f).OnComplete(() =>
               {
                   child.DOScale(normalScale, 0.3f);
               });
        }
    }

}