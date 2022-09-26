using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoThanks : MonoBehaviour
{
    [SerializeField] UITweenAnimation uITweenAnimation;
    [SerializeField] Button earnButton;
    [SerializeField] Button noButton;
    public void NoThanksButton()
    {
        noButton.enabled = false;
        earnButton.enabled = false;
        StartCoroutine(uITweenAnimation.Animate());
       // GameManager.Instance.CompleteThelevel();
    }
}