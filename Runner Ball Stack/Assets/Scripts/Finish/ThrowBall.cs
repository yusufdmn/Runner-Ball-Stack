using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ThrowBall : Finish
{
    public GameObject restartButton;   // REMOVE


    private bool canThrow;
    List<GameObject> stackedBalls;

    [SerializeField]float throwSpeed;

    [SerializeField]Vector3 cameraPos;
    [SerializeField]Vector3 cameraAngle;

    float time;
    [SerializeField] float timeGap;

    public void RestartLevel() {    // REMOVE
        SceneManager.LoadScene(0);
    }        
    private void Start()
    {
        SetStackedBallsToThrow();
        SetCamera();
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
            if (Input.GetKeyDown(KeyCode.Space) /*|| Input.GetTouch(0).phase == TouchPhase.Began*/)
            {
                ThrowNextBall(throwSpeed);
                if(stackedBalls.Count < 1)
                {
                    GameManager.Instance.EndTheGame();
                }
                MoveBallsToLine();
            }
        }
    }

    void ThrowNextBall(float throwSpeed)
    {
        Rigidbody rigidbody = stackedBalls[0].GetComponent<Rigidbody>();
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
