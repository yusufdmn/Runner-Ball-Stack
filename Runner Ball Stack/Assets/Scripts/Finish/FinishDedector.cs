using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDedector : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ThrowBall")
        {
            other.tag = "Untagged";
            //List<GameObject> stackedBalls = StackManager.Instance.stackedBalls;
            gameObject.GetComponent<FirstBallMoveForward>().enabled = false;
            other.GetComponent<Finish>().enabled = true;
        }
    }
}