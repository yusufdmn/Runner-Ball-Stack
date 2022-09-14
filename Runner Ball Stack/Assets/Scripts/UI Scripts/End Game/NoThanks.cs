using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoThanks : MonoBehaviour
{
    public void NoThanksButton()
    {
        GameManager.Instance.PassToNextLevel();
    }
}