using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    public Transform firstBall;
    [SerializeField] Vector3 offset;
    float smoothDamp = 0.15f;
    Vector3 velocity;

    public bool isFinished;
    [SerializeField] float moveDuration;

    private void Start()
    {
        offset = new Vector3(0, 7.25f, -10);
    }

    void LateUpdate()
    {
        if(!isFinished)
            FollowFirstBall();
    }

    void FollowFirstBall()
    {
        Vector3 followedPos = firstBall.position + offset;
        followedPos.x = transform.position.x;
        transform.position = Vector3.SmoothDamp(transform.position, followedPos, ref velocity, smoothDamp);
    }

    public void GetFirstBall(GameObject newFirstBall)
    {
        firstBall = newFirstBall.transform;
    }

    public void MoveAndSetAngle(Vector3 newOffset, Vector3 angle)
    {
        isFinished = true;
        Vector3 pos = transform.position + newOffset;
        transform.DOMove(pos, moveDuration);
        transform.DORotate(angle, moveDuration);
    }
}