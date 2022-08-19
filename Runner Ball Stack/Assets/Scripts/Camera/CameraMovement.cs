using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform firstBall;
    [SerializeField] Vector3 offset;
    float smoothDamp = 0.15f;
    Vector3 velocity;

    void LateUpdate()
    {
        Vector3 targetPos = firstBall.position + offset;
        targetPos.x = transform.position.x;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothDamp);
    }

    public void GetFirstBall(GameObject newFirstBall)
    {
        firstBall = newFirstBall.transform;
    }

}
