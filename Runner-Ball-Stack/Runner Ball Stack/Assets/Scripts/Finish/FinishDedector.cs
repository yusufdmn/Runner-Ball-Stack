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

            foreach (GameObject ball in StackManager.Instance.stackedBalls)
            {
                Destroy(ball.GetComponent<BallTrigger>());
            }
        }

        if(other.tag == "CircleEnd")
        {
            Camera.main.GetComponent<CameraMovement>().isFinished = true;
            GameManager.Instance.isFinishModeStarted = true;
            other.tag = "Untagged";
            other.GetComponent<Finish>().enabled = true;
            //StackManager.Instance.gameObject.SetActive(false);

            foreach (GameObject ball in StackManager.Instance.stackedBalls)
            {
                Destroy(ball.GetComponent<BallTrigger>());
            }
        }
    }
}