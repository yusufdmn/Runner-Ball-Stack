using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using RDG;

public class ThrowBall : Finish
{

    bool ispressed;
    private bool canThrow;
    List<GameObject> stackedBalls;

    [SerializeField]float throwSpeed;

    [SerializeField]Vector3 cameraPos;
    [SerializeField]Vector3 cameraAngle;

    float time;
    [SerializeField] float timeGap;

    
    private void Start()
    {
        DefineAudioManager();
        SetStackedBallsToThrow();
        SetCamera();
        Destroy(StackManager.Instance.gameObject, 1.2f);
    }
    void Update() 
    {
        if (stackedBalls.Count <= 0)
            return;
        time += Time.deltaTime;
        if (time > timeGap)
        {
            canThrow = true;
            time = 0;
        }


        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ispressed = true;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                ispressed = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ispressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
            ispressed = false;


        if (canThrow & ispressed)
        {
            ThrowNextBall(throwSpeed);
            if (stackedBalls.Count < 1)
            {
                StartCoroutine(LaunchEndOfTheGame());
            }
            MoveBallsToLine();
        }

    }

    void ThrowNextBall(float throwSpeed)
    {
        if(Settings.isVibrationOn)
            Vibration.Vibrate(35);

        Rigidbody rigidbody = stackedBalls[0].GetComponent<Rigidbody>();
        stackedBalls[0].GetComponent<RotateInAxisX>().enabled = true;
        rigidbody.isKinematic = false;
        rigidbody.velocity = Vector3.forward * throwSpeed * Time.deltaTime;
        time = 0;
        canThrow = false;
        stackedBalls.RemoveAt(0);
    }

    public void SetStackedBallsToThrow()
    {
        StackManager.Instance.MoveBallsToOrigin();
        stackedBalls = StackManager.Instance.stackedBalls;
        canThrow = true;
    }

    void SetCamera()
    {
        Camera.main.GetComponent<CameraMovement>().MoveAndSetAngle(cameraPos, cameraAngle);
    }

    void MoveBallsToLine()
    {
        foreach (GameObject ball in stackedBalls)
        {
            ball.transform.DOMoveZ(ball.transform.position.z + 1, 0.25f);
        }
    }

}
