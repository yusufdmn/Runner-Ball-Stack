using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleEnd : Finish
{
    public bool areCirclesFull;
    [SerializeField] GameObject circles;
    List<GameObject> stackedBalls;
    [SerializeField] float flyDuration;
    private void Start()
    {
        stackedBalls = StackManager.Instance.stackedBalls;
        stackedBalls[0].GetComponent<FirstBallMoveForward>().enabled = false;
        Vector3 newCamOffset = new Vector3(-2, 0, 3);
        Vector3 newCamAngle = new Vector3(90, 0, 0);
        Camera.main.GetComponent<CameraMovement>().isFinished = true;
    }
    void Update()
    {
        if (!areCirclesFull)
        {
            Vector3 circlePos = circles.transform.GetChild(0).position;
            circlePos.y += 0.7f;
            stackedBalls[0].transform.DOMove(circlePos, flyDuration);
        }
    }
}
