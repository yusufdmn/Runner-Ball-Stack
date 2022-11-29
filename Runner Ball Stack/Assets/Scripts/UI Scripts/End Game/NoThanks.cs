using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoThanks : MonoBehaviour
{
    [SerializeField] GameObject earnButtonObj;
    [SerializeField] GameObject noThanksButtonObj;
    [SerializeField] UITweenAnimation uITweenAnimation;
    [SerializeField] Button earnButton;
    [SerializeField] Button noButton;
    public void NoThanksButton()
    {
        DisableReClick();
        StartCoroutine(uITweenAnimation.Animate());
    }

    private void DisableReClick()
    {
        noButton.enabled = false;
        earnButton.enabled = false;
        noThanksButtonObj.SetActive(false);
        earnButtonObj.SetActive(false);
    }
}