using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball" && !StackManager.Instance.allBalls.Contains(other.gameObject))
        {
            GameObject newBall = other.gameObject;
            //int newBallIndex = StackManager.Instance.allBalls.Count;
            //newBall.AddComponent<FollowerBall>();
            //newBall.GetComponent<FollowerBall>().ownIndex = newBallIndex;
            newBall.AddComponent<BallTrigger>();
            newBall.tag = "Untagged";
            StackManager.Instance.StackBalls(newBall);
        }
    }


}
