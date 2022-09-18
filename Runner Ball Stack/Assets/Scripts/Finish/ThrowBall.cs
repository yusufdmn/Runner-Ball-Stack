using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ThrowBall : Finish
{
    private bool canThrow;
    List<GameObject> stackedBalls;

    [SerializeField]float throwSpeed;

    [SerializeField]Vector3 cameraPos;
    [SerializeField]Vector3 cameraAngle;

    float time;
    [SerializeField] float timeGap;

    
    private void Start()
    {
        SetStackedBallsToThrow();
        SetCamera();
        Destroy(StackManager.Instance.gameObject, 1.2f);
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

            if(Input.touchCount > 0)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    ThrowNextBall(throwSpeed);
                    if (stackedBalls.Count < 1)
                    {
                        StartCoroutine(LaunchEndOfTheGame());
                    }
                    MoveBallsToLine();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ThrowNextBall(throwSpeed);
                if(stackedBalls.Count < 1)
                {
                    StartCoroutine(LaunchEndOfTheGame());
                }
                MoveBallsToLine();
            }
        }
    }

    IEnumerator LaunchEndOfTheGame()
    {
        yield return new WaitForSeconds(3f);
        GameManager.Instance.EndTheGame();
    }

    void ThrowNextBall(float throwSpeed)
    {
        Rigidbody rigidbody = stackedBalls[0].GetComponent<Rigidbody>();
        stackedBalls[0].GetComponent<RotateInAxisX>().enabled = true;
        rigidbody.isKinematic = false;
        rigidbody.velocity = Vector3.forward * throwSpeed * Time.deltaTime;

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
            ball.transform.DOMoveZ(ball.transform.position.z + 1, 1f);
        }
    }
}
