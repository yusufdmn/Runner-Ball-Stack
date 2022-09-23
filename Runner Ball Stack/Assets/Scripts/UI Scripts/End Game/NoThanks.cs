using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoThanks : MonoBehaviour
{
    [SerializeField] UITweenAnimation uITweenAnimation;

    public void NoThanksButton()
    {
        StartCoroutine(uITweenAnimation.Animate());
       // GameManager.Instance.CompleteThelevel();
    }
}