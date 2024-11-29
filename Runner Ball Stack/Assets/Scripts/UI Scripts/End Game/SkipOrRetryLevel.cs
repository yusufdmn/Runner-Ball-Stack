using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipOrRetryLevel : MonoBehaviour
{
    public void SkipLevel()
    {
        GameManager.Instance.CompleteThelevel();
    }
    public void RetryLevel()
    {
        GameManager.Instance.RetryLevel();
    }
}
