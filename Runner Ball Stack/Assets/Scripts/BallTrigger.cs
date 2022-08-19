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
            newBall.AddComponent<BallTrigger>();
          //  newBall.tag = "Untagged";
            StackManager.Instance.StackBalls(newBall);
        }
    }


}
