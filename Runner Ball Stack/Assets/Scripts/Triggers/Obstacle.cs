using RDG;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    bool isFailed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FirstBall")
        {
            DestroyBall(other.gameObject);
            FinishIfBallsEnded();

            if (isFailed)
                return;

            AssignNewFirstBall();
        }
        else if (other.tag == "ball")
        {
            DestroyBall(other.gameObject);
            FinishIfBallsEnded();
            if (isFailed)
                return;
        }
    }


    private void DestroyBall(GameObject ball)
    {
        if(Settings.isVibrationOn)
            Vibration.Vibrate(55);
        StackManager.Instance.stackedBalls.Remove(ball);
        ball.SetActive(false);
    }

    void FinishIfBallsEnded()
    {
        if (StackManager.Instance.stackedBalls.Count < 1)
        {
            GameManager.Instance.Failed();
            isFailed = true;
        }
    }

    private void AssignNewFirstBall()
    {
        GameObject newFirstBall = StackManager.Instance.stackedBalls[0];
        newFirstBall.AddComponent<FirstBallMoveForward>();
        newFirstBall.AddComponent<FinishDedector>();
        newFirstBall.tag = "FirstBall";

        AssignFirstBallForCameraFollow(newFirstBall);
    }

    private void AssignFirstBallForCameraFollow(GameObject newFirstBall)
    {
        Camera.main.GetComponent<CameraMovement>().GetFirstBall(newFirstBall);
    }
}
