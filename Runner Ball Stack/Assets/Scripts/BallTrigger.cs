using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball" && !StackManager.Instance.stackedBalls.Contains(other.gameObject))
        {
            GameObject newStackedBall = other.gameObject;
            AddBallIntoStack(newStackedBall);
        }
    }

    private void AddBallIntoStack(GameObject newStackedBall)
    {
        newStackedBall.AddComponent<BallTrigger>();
        StackManager.Instance.StackBalls(newStackedBall);
    }

}
