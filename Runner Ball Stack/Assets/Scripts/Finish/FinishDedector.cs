using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDedector : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ThrowBall")
        {
            GameManager.Instance.isFinishModeStarted = true;
            other.tag = "Untagged";
            gameObject.GetComponent<FirstBallMoveForward>().enabled = false;
            other.GetComponent<Finish>().enabled = true;
        }

        if(other.tag == "CircleEnd")
        {
            GameManager.Instance.isFinishModeStarted = true;
            other.tag = "Untagged";
            other.GetComponent<Finish>().enabled = true;
        }
    }
}