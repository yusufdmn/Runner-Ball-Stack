using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleEnd : Finish
{
    [SerializeField] ParticleSystem confetti1;
    [SerializeField] ParticleSystem confetti2;

    public bool areCirclesFull = false;
    bool areBallsFinished = false;

    [SerializeField] GameObject circles;
    List<GameObject> stackedBalls;
    [SerializeField] float flyDuration;
    int indexOfNextCircle;
    int circleAmount;
    Vector3[] circlePositions;

    Vector3 cameraPos = new Vector3(-2, 2, -4);
    Vector3 cameraAngle = new Vector3(35, 0, 0);

    [SerializeField] Transform lastSpot;
    private void Start()
    {
        SetCamera();

        StackManager.Instance.MoveBallsToOrigin();
        Destroy(StackManager.Instance.gameObject);

        circleAmount = circles.transform.childCount;
        circlePositions = new Vector3[circleAmount];
        for (int i = 0; i < circleAmount; i++)
        {
            circlePositions[i] = circles.transform.GetChild(i).position;
        }
        stackedBalls = StackManager.Instance.stackedBalls;
        stackedBalls[0].GetComponent<FirstBallMoveForward>().enabled = false;

    }

    void Update()
    {
        if (stackedBalls.Count <= 0)
            return;

        Vector3 moveVector = new Vector3(0, 0, 7);
        
        foreach (GameObject ball in stackedBalls)
            ball.transform.Translate(moveVector * Time.deltaTime, Space.World);
    }

    public IEnumerator FlyNextBallToCircle()
    {
        yield return new WaitForEndOfFrame();
        areCirclesFull = CheckIfCirclesFull();

        if (stackedBalls.Count > 0)
        {
            Vector3 circlePos = circlePositions[indexOfNextCircle];
            circlePos.y += 0.7f;
            stackedBalls[0].transform.DOMove(circlePos, flyDuration);
            indexOfNextCircle++;
            stackedBalls.Remove(stackedBalls[0]);


            if (stackedBalls.Count < 2)
                StartCoroutine(LaunchEndOfTheGame());
        }
    }

    public IEnumerator FlyNextBallToLastSpot()
    {
        yield return new WaitForEndOfFrame();
        Vector3 targetPos = lastSpot.position;
        targetPos.y += 0.5f;
        stackedBalls[0].transform.DOMove(targetPos, flyDuration);
        indexOfNextCircle++;
        stackedBalls.Remove(stackedBalls[0]);

        if (stackedBalls.Count < 2)
            StartCoroutine(LaunchEndOfTheGame());
    }

    public bool CheckIfCirclesFull()
    {
        bool isFull = (indexOfNextCircle >= circleAmount-1) ? true : false;
        return isFull;
    }

    void SetCamera()
    {
        Camera.main.GetComponent<CameraMovement>().MoveAndSetAngle(cameraPos, cameraAngle);
    }


    IEnumerator LaunchEndOfTheGame()
    {
        confetti1.Play();
        confetti2.Play();
        yield return new WaitForSeconds(3f);
        GameManager.Instance.EndTheGame();
    }
}