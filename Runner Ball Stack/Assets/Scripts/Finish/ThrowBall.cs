using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ThrowBall : Finish
{
    private bool canThrow;
    List<GameObject> stackedBalls;

    [SerializeField]float throwSpeed;

    [SerializeField]Vector3 cameraPos;
    [SerializeField]Vector3 cameraAngle;
    float cameraMoveDuraiton = 1;

    float time;
    [SerializeField] float timeGap;
    private void Start()
    {
        SetStackedBallsToThrow();
        SetCamera();
        StackManager.Instance.MoveBallsToOrigin();
        Destroy(StackManager.Instance.gameObject, 0.5f);
        foreach (GameObject ball in stackedBalls)
        {
            Destroy(ball.GetComponent<BallTrigger>());
        }

    }
    void Update() 
    {
        time += Time.deltaTime;
        if (time > timeGap)
        {
            canThrow = true;
            time = 0;
        }

        if (canThrow)
        {                
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ThrowNextBall(throwSpeed);
                stackedBalls.RemoveAt(0);
                canThrow = false;
                foreach (GameObject ball in stackedBalls)
                {
                    ball.transform.DOMoveZ(ball.transform.position.z + 1, 1f);
                }
            }
        }
    }

    void ThrowNextBall(float throwSpeed)
    {
        Rigidbody rigidbody = stackedBalls[0].GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.velocity = Vector3.forward * throwSpeed * Time.deltaTime;
    }

    public void SetStackedBallsToThrow()
    {
        stackedBalls = StackManager.Instance.stackedBalls;
        canThrow = true;
    }

    void SetCamera()
    {
        Camera.main.GetComponent<CameraMovement>().MoveAndSetAngle(cameraPos, cameraAngle, cameraMoveDuraiton);
    }

    void TimerToThrow(float time, float timeLimit)
    {
        time += Time.deltaTime;
        if(time > timeLimit)
        {
            canThrow = true;
            time = 0;
        }
    }
}
