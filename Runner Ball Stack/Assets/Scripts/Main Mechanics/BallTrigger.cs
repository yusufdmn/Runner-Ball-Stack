using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    private void OnDisable()
    {
        gameObject.GetComponent<RotateInAxisX>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball" && !StackManager.Instance.stackedBalls.Contains(other.gameObject))
        {
            Handheld.Vibrate();

            GameObject newStackedBall = other.gameObject;
            AddBallIntoStack(newStackedBall);
        }
    }

    private void AddBallIntoStack(GameObject newStackedBall)
    {
        newStackedBall.AddComponent<BallTrigger>();
        newStackedBall.AddComponent<RotateInAxisX>().rotateSpeed = 230;
        StackManager.Instance.StackBalls(newStackedBall);
    }

}
