using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FirstBall")
        {
            DestroyBall(other.gameObject);

            GameObject newFirstBall = StackManager.Instance.stackedBalls[0];
            AssignNewFirstBall(newFirstBall);
            AssignFirstBallForCameraFollow(newFirstBall);
        }
        else if (other.tag == "ball")
            DestroyBall(other.gameObject);
    }

    private void DestroyBall(GameObject ball)
    {
        StackManager.Instance.stackedBalls.Remove(ball);
        Destroy(ball);
    }

    private void AssignNewFirstBall(GameObject newFirstBall)
    {
        newFirstBall.tag = "FirstBall";
        newFirstBall.AddComponent<FirstBallMoveForward>();
    }

    private void AssignFirstBallForCameraFollow(GameObject newFirstBall)
    {
        Camera.main.GetComponent<CameraMovement>().GetFirstBall(newFirstBall);
    }
}
