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

    void LateUpdate()
    {
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

    public void MoveAndSetAngle(Vector3 newOffset, Vector3 angle, float moveDuration)
    {
        Vector3 pos = transform.position + newOffset;
        transform.DOMove(pos, moveDuration);
        transform.DORotate(angle, moveDuration).OnComplete(() =>
            this.enabled = false
        ); ;
    }
}